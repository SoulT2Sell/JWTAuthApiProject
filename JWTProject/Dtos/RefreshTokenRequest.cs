using System.ComponentModel.DataAnnotations;
namespace JWTProject.Dtos
{
    public record RefreshTokenRequest
    {
        [Required]
        public Guid UserId { get; init; }
        [Required]
        public string RefreshToken { get; init; } = string.Empty;
    }
}
