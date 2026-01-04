namespace JWTProject.Dtos
{
    public record TokensResponse
    {
        public required string AccessToken { get; init; }    
        public required string RefreshToken { get; init; }
    }
}
