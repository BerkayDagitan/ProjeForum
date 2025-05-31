using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using EntityLayer.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Services
{
    public class UserApiServices : IUserApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly IUserRepository _repo;
        private readonly IConfiguration _configuration;

        public UserApiServices(HttpClient httpClient, IUserRepository repo, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _repo = repo;
            _configuration = configuration;

            var baseUrl = _configuration["ApiSettings:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentNullException(nameof(baseUrl), "API Base URL yapılandırması eksik.");
            }
            _httpClient.BaseAddress = new Uri(baseUrl);
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
            StringContent content = new StringContent(JsonConvert.SerializeObject(userRegisterDTO));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync("user/Register", content);

            return result.IsSuccessStatusCode;
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
