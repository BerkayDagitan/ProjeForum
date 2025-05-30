using EntityLayer.Entitys;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string username);
    }
}