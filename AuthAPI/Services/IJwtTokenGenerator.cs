using AuthAPI.Models;

namespace AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(CustomUser customUser);
    }
}
