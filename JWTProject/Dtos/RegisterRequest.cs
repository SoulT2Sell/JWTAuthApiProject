using System.ComponentModel.DataAnnotations;
namespace JWTProject.Dtos
{
    public record RegisterRequest {
        [Required(ErrorMessage = "Userame is Required")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 Characters", MinimumLength = 3)]
        public string Username { get; init; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 Characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; init; } = string.Empty;

        [Required(ErrorMessage = "ConfirmPassword is Required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 Characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; init; } = string.Empty;
    }
}
