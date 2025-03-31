using Angular_Api.Domain.Repositories;
using Angular_Api.Domain.Entities;
using Angular_Api.Domain.Repositories;

namespace Angular_Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> GetAllUsers()
        {
            // Implémentation simulée : retourner une liste statique d'utilisateurs
            return new List<User>
            {
                new User { Id = 1, Name = "Alice", Email = "alice@example.com" },
                new User { Id = 2, Name = "Bob", Email = "bob@example.com" },
                new User { Id = 3, Name = "John", Email = "John@example.com" }
            };
        }
    }
}