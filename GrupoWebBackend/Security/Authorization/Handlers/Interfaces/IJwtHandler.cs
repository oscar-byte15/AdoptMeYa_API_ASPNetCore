using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.Security.Authorization.Handlers.Interfaces
{
    public interface IJwtHandler
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}