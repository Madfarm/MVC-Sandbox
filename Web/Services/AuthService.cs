using AuthAPI.Models.Dto;
using Web.Models;
using Web.Services.IServices;

namespace Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public Task<ResponseDto?> Login(LoginRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> Register(RegistrationRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
