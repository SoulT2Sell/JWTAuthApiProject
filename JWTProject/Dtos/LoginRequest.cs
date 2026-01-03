using System.ComponentModel.DataAnnotations;
namespace JWTProject.Dtos
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is Required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        public string Username { get; init; } = string.Empty;

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(255, ErrorMessage = " Must be between 5 and 255", MinimumLength = 5)]
        public string Password { get; init; } = string.Empty;
    }
}
