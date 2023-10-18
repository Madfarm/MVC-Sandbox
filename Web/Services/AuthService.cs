using AuthAPI.Models.Dto;
using Web.Models;
using Web.Services.IServices;
using Web.Utility;

namespace Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;

        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> Login(LoginRequestDto request)
        {
            return await _baseService.SendDataAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "api/auth/login",
                Data = request
            });
        }

        public async Task<ResponseDto?> Register(RegistrationRequestDto request)
        {
            return await _baseService.SendDataAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "api/auth/register",
                Data = request
            });
        }

        public async Task<ResponseDto?> AssignRole(RegistrationRequestDto request)
        {
            return await _baseService.SendDataAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthAPIBase + "api/auth/assign-role",
                Data = request
            });
        }
    }
}
