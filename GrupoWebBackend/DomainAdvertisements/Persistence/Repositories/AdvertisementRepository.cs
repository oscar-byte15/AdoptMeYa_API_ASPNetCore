using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Domain.Repositories;
using GrupoWebBackend.Shared.Persistence.Context;
using GrupoWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrupoWebBackend.DomainAdvertisements.Persistence.Repositories
{
    public class AdvertisementRepository:BaseRepository,IAdvertisementRepository
    {
        public AdvertisementRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Advertisement>> ListAdvertisementAsync()
        {
            //USING framework net
            
            return await _context.Advertisements.ToListAsync();
        }

        public async Task AddAsync(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
        }

        public async Task<Advertisement> FindByIdAsync(int id)
        {
            return await _context.Advertisements.FindAsync(id);
        }
        public async Task<Advertisement> FindByTitleAsync(string title)
        {
            return await _context.Advertisements.Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Title == title);
        }

        public void Update(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
        }

        public void Remove(Advertisement advertisement)
        {
            _context.Advertisements.Remove(advertisement);
        }

        public async Task<IEnumerable<Advertisement>> FindByUserId(int userId)
        {
            return await _context.Advertisements.Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();

        }

        public IEnumerable<Advertisement> GetAdvertisementWithDiscount(bool promoted)
        {
            return _context.Advertisements.Where(p => p.Promoted.Equals(promoted)).Where(p=>p.Promoted==true);
        }
    }
}