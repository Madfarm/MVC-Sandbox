﻿using AuthAPI.Models.Dto;

namespace AuthAPI.Services
{
    public interface IAuthService
    {
        public Task<string> Register(RegistrationRequestDto registrationRequestDto);
        public Task<LoginResponse> Login(LoginRequestDto loginRequestDto);

        public Task<bool> AssignRole(string email, string roleName);
    }
}
