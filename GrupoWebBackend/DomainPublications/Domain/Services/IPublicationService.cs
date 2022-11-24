using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.DomainPublications.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Resources;

namespace GrupoWebBackend.DomainPublications.Domain.Services
{
    public interface IPublicationService
    {
        Task<IEnumerable<Publication>> ListPublicationAsync();
        Task<IEnumerable<Publication>> ListByUserId(int userId);
        Task<PublicationResponse> SaveAsync(Publication publication);
        Task<PublicationResponse> UpdateAsync(int id, Publication publication);
        Task<PublicationResponse> DeleteAsync(int id);

    }
}