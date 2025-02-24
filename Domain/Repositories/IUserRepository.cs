using Angular_Api.Domain.Entities;

namespace Angular_Api.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
    }
}