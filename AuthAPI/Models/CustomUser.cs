using Microsoft.AspNetCore.Identity;

namespace AuthAPI.Models
{
    public class CustomUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
