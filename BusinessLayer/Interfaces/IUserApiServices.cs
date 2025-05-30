using EntityLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    public interface IUserApiServices
    {
        Task<bool> RegisterUserAsync(UserRegisterDTO userRegisterDTO);
        Task<LoginResponseDTO> LoginUserAsync(UserLoginDTO userLoginDTO);
        Task<bool> IsUserExistsAsync(string email);
        Task<UserLoginDTO> ValidateUser(string username, string password);
    }
}