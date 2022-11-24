using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainDistrict.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Domain.Models;

namespace GrupoWebBackend.DomainDistrict.Domain.Repositories
{
    public interface IDistrictRepository
    { 
        Task<IEnumerable<District>> ListAsync();
        Task<District> FindAsync(int id);
        Task AddAsync(District district);
        void UpdateAsync(District district);
        void Delete(District district);
        
    }
}