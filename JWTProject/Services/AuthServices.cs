using JWTProject.Data;
using JWTProject.Dtos;
using JWTProject.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTProject.Services
{
    public class AuthServices(IConfiguration configuration, AppDbContext context) : IAuthServices
    {
        public async Task<string> LoginAsync(LoginRequest request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, request.Password)
                == PasswordVerificationResult.Failed)
            {
                return null;
            }

            string token = CreateToken(user);
            return token;
            
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest request)
        {
            if (await context.Users.AnyAsync(u => u.Username == request.Username))
            {
                return null;
            }

            var user = new User();

            user.Username = request.Username;
            user.HashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var response = new UserResponse()
            {
                Id = user.Id,
                UserName = user.Username,
                Password = user.HashedPassword,
                Role = user.Role,
            };

            return response;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                    issuer: configuration.GetValue<string>("Jwt:Issuer"),
                    audience: configuration.GetValue<string>("Jwt:Audience"),
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
