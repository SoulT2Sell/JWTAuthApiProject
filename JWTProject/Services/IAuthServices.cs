using JWTProject.Dtos;

namespace JWTProject.Services
{
    public interface IAuthServices
    {
        Task<UserResponse?> RegisterAsync(RegisterRequest request);
        Task<TokensResponse?> LoginAsync(LoginRequest request);
        Task<TokensResponse?> RefreshTokensAsync(RefreshTokenRequest request);
    }
}
