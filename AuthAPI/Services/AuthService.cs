using AuthAPI.Data;
using AuthAPI.Models;
using AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;
using System;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(DataContext db, UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<LoginResponse> Login(LoginRequestDto loginRequestDto)
        {   
            //Check if user exists
            //Check if password is correct
            // If either is fucked, return an empty login response
            //Create user dto
            // Create login response
            // return login response

            var user = _db.Users.FirstOrDefault(u => u.UserName == loginRequestDto.UserName);
            var isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || !isValid) 
            {
                return new LoginResponse() { User = new(), Token = "" };
            }

            UserDto userDto = new()
            {
                Id = user.Id,
                Name = user.Name,

            };

            LoginResponse loginResponse = new()
            {
                User = userDto,
                Token = ""
            };

            return loginResponse;
        }

        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            CustomUser user = new()
            {
                Name = registrationRequestDto.Name,
                Email = registrationRequestDto.Email,
                UserName = registrationRequestDto.Email,
                
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);

                if(result.Succeeded)
                {
                    var returnedUser = _db.Users.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Id = returnedUser.Id,
                        Name = returnedUser.Name
                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception e)
            {
                
            }

            return "Error Encountered";
        }
    }
}
