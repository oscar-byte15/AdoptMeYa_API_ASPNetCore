using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GrupoWebBackend.Security.Domain.Entities;
using GrupoWebBackend.Security.Domain.Repositories;
using GrupoWebBackend.Shared.Persistence.Context;
using GrupoWebBackend.Shared.Persistence.Repositories;

namespace GrupoWebBackend.Security.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserNick == username);
        }

        public bool ExistsByUsername(string username)
        {
            return _context.Users.Any(u => u.UserNick == username);
        }

        public User FindById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

    }
}