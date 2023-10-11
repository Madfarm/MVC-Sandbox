namespace AuthAPI.Models.Dto
{
    // Add a new attribute
    public class RegistrationRequestDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
