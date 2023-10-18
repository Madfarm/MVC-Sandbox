using Web.Models;

namespace Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> Login(LoginRequestDto request);
        Task<ResponseDto?> Register(RegistrationRequestDto request);

        Task<ResponseDto?> AssignRole(RegistrationRequestDto request);
    }
}
