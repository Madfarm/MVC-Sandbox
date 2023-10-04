namespace AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken();
    }
}
