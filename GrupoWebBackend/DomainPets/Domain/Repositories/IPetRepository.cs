using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Domain.Models;

namespace GrupoWebBackend.DomainPets.Domain.Repositories
{
    public interface IPetRepository
    { 
        Task<IEnumerable<Pet>> ListAsync();
        Task<Pet> FindAsync(int id);
        Task AddAsync(Pet pet);
        void UpdateAsync(Pet pet);
        void Delete(Pet pet);
        IEnumerable<Pet> GetPet(int userId);
        
        Task<IEnumerable<Pet>> ListPublicationsGender(string gender);
        Task<IEnumerable<Pet>> ListPublicationsType(string type);
        Task<IEnumerable<Pet>> ListPublicationsAttention(string attention);
        Task<IEnumerable<Pet>> ListPublicationsGenderAttention(string gender, string attention);
        Task<IEnumerable<Pet>> ListPublicationsTypeAttention(string type, string attention);
        Task<IEnumerable<Pet>> ListPublicationsTypeGender(string type, string gender);
        Task<IEnumerable<Pet>> ListPublicationsTypeGenderAttention(string type, string gender, string attention);
    }
}