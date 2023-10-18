using AuthAPI.Models.Dto;

namespace Web.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginResponse?> Login(LoginRequestDto request);
        Task<RegistrationRequestDto> Register(RegistrationRequestDto request);
    }
}
