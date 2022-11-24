using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Repositories;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.Shared.Persistence.Context;
using GrupoWebBackend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GrupoWebBackend.DomainPets.Persistence.Repositories
{
    public class PetRepository: BaseRepository, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _context.Pets.ToListAsync();
        }
        public async Task<Pet> FindAsync(int id)
        {
            return await _context.Pets.FindAsync(id);   
        }
        public async Task AddAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
        }

        public void UpdateAsync(Pet pet)
        {
            _context.Pets.Update(pet);
        }

        public void Delete(Pet pet)
        {
            _context.Pets.Remove(pet);
        }

        public IEnumerable<Pet> GetPet(int userId)
        {
            return _context.Pets.Where(p => p.UserId.Equals(userId)).ToList();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsGender(string gender)
        {
            return await _context.Pets.Where(p => p.Gender == gender).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsType(string type)
        {
            return await _context.Pets.Where(p => p.Type == type).ToListAsync();

        }

        public async Task<IEnumerable<Pet>> ListPublicationsAttention(string attention)
        {
            return await _context.Pets.Where(p => p.Attention == attention).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsGenderAttention(string gender, string attention)
        {
            return await _context.Pets.Where(p => p.Gender == gender).
                Where(p => p.Attention == attention).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeAttention(string type, string attention)
        {
            return await _context.Pets.Where(p => p.Type == type).
                Where(p => p.Attention == attention).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeGender(string type, string gender)
        {
            return await _context.Pets.Where(p => p.Type == type).
                Where(p => p.Gender == gender).ToListAsync();
        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeGenderAttention(string type, string gender, string attention)
        {
            return await _context.Pets.Where(p => p.Type == type).
                Where(p => p.Gender == gender).
                Where(p => p.Attention == attention).ToListAsync();
        }
    }
}