using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.Security.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        public bool ExistsByUsername(string username);
        User FindById(int id);
        void Update(User user);
        void UpdateUser(User user);
        void Remove(User user);
    }
}