using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(IConfiguration configuration, int userId, string username, string role);
        int GetUserIdFromToken(string token);
    }
}