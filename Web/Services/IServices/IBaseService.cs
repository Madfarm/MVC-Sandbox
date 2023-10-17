using AuthAPI.Models.Dto;

namespace Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendDataAsync(RequestDto);
    }
}
