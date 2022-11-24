using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Domain.Services.Communications;

namespace GrupoWebBackend.DomainAdvertisements.Domain.Services
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<Advertisement>> ListAdvertisementAsync();
        Task<IEnumerable<Advertisement>> ListByUserId(int userId);
        Task<AdvertisementResponse> SaveAsync(Advertisement advertisement);
        Task<AdvertisementResponse> UpdateAsync(int id, Advertisement advertisement);
        Task<AdvertisementResponse> DeleteAsync(int id);
        IEnumerable<Advertisement> GetAdvertisementsWithDiscount(bool promoted);
    }
}