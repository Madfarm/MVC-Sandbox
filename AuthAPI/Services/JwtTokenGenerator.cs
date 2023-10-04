using AuthAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace AuthAPI.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(JwtOptions jwtOptions)
        {
            _jwtOptions = jwtOptions;
        }

        public string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
        }
    }
}
