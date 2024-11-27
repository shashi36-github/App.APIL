namespace PetApp.Models
{
    public class UserRequest
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? Name { get; set; }
        public long? Phone { get; set; }
    }
}
