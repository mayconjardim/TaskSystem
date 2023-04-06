using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {

        Task<List<UserModel>> FindAllUsers();

        Task<UserModel> FindById(int id);

        Task<UserModel> create(UserModel user);

        Task<UserModel> update(UserModel user);

        Task<bool> delete(int id);

    }
}
