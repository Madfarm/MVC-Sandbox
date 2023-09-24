using AuthAPI.Models.Dto;

namespace AuthAPI.Services
{
    public interface IAuthService
    {
        public Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        public Task<LoginResponse> Login(LoginRequestDto loginRequestDto);
    }
}
