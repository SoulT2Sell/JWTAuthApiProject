namespace JWTProject.Dtos
{
    public record UserResponse
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }
}
