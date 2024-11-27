using PetApp.Models;

namespace PetApp.Services
{
    public class UserValidator
    {
        public string? ValidateNew(UserRequest request)
        {
            if (string.IsNullOrEmpty(request.Username))
                return "Username is required.";
            if (string.IsNullOrEmpty(request.Password))
                return "Password is required.";
            if (string.IsNullOrEmpty(request.Email))
                return "Email is required.";
            // Additional validations can be added here
            return null;
        }

        public string? ValidateExistingUser(UserDB? user)
        {
            if (user == null)
                return "Invalid username or password.";
            return null;
        }
    }
}
