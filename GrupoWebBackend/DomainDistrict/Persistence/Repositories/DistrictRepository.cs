using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoWebBackend.DomainDistrict.Domain.Models;
using GrupoWebBackend.DomainDistrict.Domain.Repositories;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Repositories;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.Shared.Persistence.Context;
using GrupoWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrupoWebBackend.DomainDistrict.Persistence.Repositories
{
    public class DistrictRepository: BaseRepository, IDistrictRepository
    {
        public DistrictRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _context.Districts.ToListAsync();
        }
        public async Task<District> FindAsync(int id)
        {
            return await _context.Districts.FindAsync(id);   
        }
        public async Task AddAsync(District district)
        {
            await _context.Districts.AddAsync(district);
        }

        public void UpdateAsync(District district)
        {
            _context.Districts.Update(district);
        }

        public void Delete(District district)
        {
            _context.Districts.Remove(district);
        }

    }
}