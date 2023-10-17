using AuthAPI.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class BaseService : IBaseService
    {
        public Task<ResponseDto?> SendDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
