using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.DomainPublications.Domain.Repositories;
using GrupoWebBackend.DomainPublications.Resources;
using GrupoWebBackend.Shared.Persistence.Context;
using GrupoWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GrupoWebBackend.DomainPublications.Persistence.Repositories
{
    public class PublicationRepository:BaseRepository,IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Publication>> ListPublicationsAsync()
        {
            //USING framework net
            
            return await _context.Publications.ToListAsync();
        }

        public async Task AddAsync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindByIdAsync(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public async Task<IEnumerable<Publication>> FindByUserId(int userId)
        {
            return await _context.Publications.Where(p => p.UserId == userId)
                .Include(p => p.User)
                .ToListAsync();
        }
    }
}