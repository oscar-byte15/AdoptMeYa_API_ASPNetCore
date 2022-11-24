using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.Security.Domain.Entities;
using GrupoWebBackend.Security.Domain.Services.Communication;

namespace GrupoWebBackend.Security.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<User> GetByIdAsync(int id);
        Task RegisterAsync(RegisterRequest request);
        Task UpdateAsync(int id, UpdateRequest request);
        Task DeleteAsync(int id);

        Task<UserResponse> UpdateUser(User user, int id);
    }
}