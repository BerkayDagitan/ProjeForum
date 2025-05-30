namespace EntityLayer.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public UserLoginDTO User { get; set; }
    }
}