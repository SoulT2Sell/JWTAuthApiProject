using JWTProject.Dtos;

namespace JWTProject.Services
{
    public interface IAuthServices
    {
        Task<UserResponse> RegisterAsync(RegisterRequest request);
        Task<string> LoginAsync(LoginRequest request);
    }
}
