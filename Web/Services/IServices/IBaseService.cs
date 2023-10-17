using Web.Models;

namespace Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendDataAsync(RequestDto requestDto);
    }
}
