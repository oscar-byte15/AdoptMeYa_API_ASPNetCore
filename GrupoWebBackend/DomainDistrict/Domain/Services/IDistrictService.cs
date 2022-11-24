using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainDistrict.Domain.Models;
using GrupoWebBackend.DomainDistrict.Domain.Services.Communications;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;

namespace GrupoWebBackend.DomainDistrict.Domain.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> ListAsync();
        Task<District> FindAsync(int id);
        Task<SaveDistrictResponse> AddAsync(District district);
        Task<DistrictResponse> UpdateAsync(District district, int id);
        Task<DistrictResponse> DeleteAsync(int id);

    }
    
}