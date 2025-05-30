using EntityLayer.DTOs;
using DataAccessLayer.Interfaces;
using Org.BouncyCastle.Crypto.Generators;

namespace DataAccessLayer.Services
{
    public class UserApiServices : IUserApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _repo;

        public UserApiServices(HttpClient httpClient, IUserRepository repo)
        {
            _httpClient = httpClient;
            _repo = repo;
        }

        public async Task<bool> IsUserExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponseDTO> LoginUserAsync(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDTO userRegisterDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserLoginDTO> ValidateUser(string username, string password)
        {
            try
            {
                var user = await _repo.GetUserByUsername(username);
                if (user == null)
                {
                    return null;
                }

                bool isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (!isValidPassword)
                {
                    return null;
                }

                return new UserLoginDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Role = user.Role
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı doğrulama sırasında bir hata oluştu", ex);
            }
        }
    }
}
