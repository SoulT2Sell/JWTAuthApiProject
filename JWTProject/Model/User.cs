namespace JWTProject.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string HashedPassword { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTockenExpiryTime { get; set; }   
    }
}
