using System.Threading.Tasks;

namespace GrupoWebBackend.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}