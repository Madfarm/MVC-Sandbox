using AuthAPI.Models.Dto;
using Web.Services.IServices;

namespace Web.Services
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponse?> Login(LoginRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationRequestDto> Register(RegistrationRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
