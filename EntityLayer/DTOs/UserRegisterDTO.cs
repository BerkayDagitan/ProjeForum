namespace EntityLayer.DTOs
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }= DateTime.Now;
    }
}