using AuthAPI.Models.Dto;
using System.Net.Http;
using System.Text;
using Web.Services.IServices;
using static Web.Utility.SD;

namespace Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _httpClientFactory.CreateClient("FakesturantAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            // token to be implemented later

            message.RequestUri = new Uri(requestDto.Url);

            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);

            try
            {
                switch (apiResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.NotFound:
                        return new() { IsSuccssful = false, Message = "Not Found" };
                    case System.Net.HttpStatusCode.Forbidden:
                        return new() { IsSuccssful = false, Message = "Access Denied" };
                    case System.Net.HttpStatusCode.Unauthorized:
                        return new() { IsSuccssful = false, Message = "Unauthorized" };
                    case System.Net.HttpStatusCode.InternalServerError:
                        return new() { IsSuccssful = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccssful = false
                };
                return dto;
            }
        }
    }
}
