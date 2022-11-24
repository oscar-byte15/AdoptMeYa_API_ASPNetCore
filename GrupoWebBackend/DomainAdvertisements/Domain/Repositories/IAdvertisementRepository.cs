using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;

namespace GrupoWebBackend.DomainAdvertisements.Domain.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<IEnumerable<Advertisement>> ListAdvertisementAsync();
        Task AddAsync(Advertisement advertisement);
        Task<Advertisement> FindByIdAsync(int id);
        void Update(Advertisement advertisement);
        void Remove(Advertisement advertisement);
        Task<Advertisement> FindByTitleAsync(string title);
        Task<IEnumerable<Advertisement>> FindByUserId(int userId);
        IEnumerable<Advertisement> GetAdvertisementWithDiscount(bool promoted);
    }
}