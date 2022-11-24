using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;

namespace GrupoWebBackend.DomainPets.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> ListAsync();
        Task<Pet> FindAsync(int id);
        Task<SavePetResponse> AddAsync(Pet publication);
        Task<PetResponse> UpdateAsync(Pet pet, int id);
        IEnumerable<Pet> GetPet(int userId);
        Task<PetResponse> DeleteAsync(int id);
        Task<IEnumerable<Pet>> ListPublicationsGender(string gender);
        Task<IEnumerable<Pet>> ListPublicationsType(string type);
        Task<IEnumerable<Pet>> ListPublicationsAttention(string attention);
        Task<IEnumerable<Pet>> ListPublicationsGenderAttention(string gender, string attention);
        Task<IEnumerable<Pet>> ListPublicationsTypeAttention(string type, string attention);
        Task<IEnumerable<Pet>> ListPublicationsTypeGender(string type, string gender);
        Task<IEnumerable<Pet>> ListPublicationsTypeGenderAttention(string type, string gender, string attention);

    }
    
}