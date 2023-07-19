using MvcStartApp.Models.Db;

namespace MvcStartApp.Controllers.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
