using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Repositories;
using GrupoWebBackend.DomainPets.Domain.Services;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Domain.Repositories;
using GrupoWebBackend.Shared.Domain.Repositories;

namespace GrupoWebBackend.DomainPets.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublicationRepository _publicationRepository;

        public PetService(IPetRepository petRepository, IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
            _publicationRepository = publicationRepository;
        }

        public async Task<IEnumerable<Pet>> ListAsync()
        {
            return await _petRepository.ListAsync();
        }



        public async Task<Pet> FindAsync(int id)
        {
            return await _petRepository.FindAsync(id);
        }
        
        public async Task<SavePetResponse> AddAsync(Pet pet)
        {
            var existingUser = _publicationRepository.FindByUserId(pet.UserId);
            if (existingUser == null)
                return new SavePetResponse("invalid user");
            
            try
            {
                await _petRepository.AddAsync(pet);
                await _unitOfWork.CompleteAsync();
                return new SavePetResponse(pet);
            }
            catch (Exception e)
            {
                return new SavePetResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<PetResponse> UpdateAsync(Pet pet, int id)
        {
            var existingPet = await _petRepository.FindAsync(id);
            if (existingPet == null)
                return new PetResponse("Pet not found");
            existingPet.Age = pet.Age;
            existingPet.Attention = pet.Attention;
            existingPet.Name = pet.Name;
            existingPet.Race = pet.Race;
            existingPet.Type = pet.Type;
            existingPet.IsAdopted = pet.IsAdopted;

            try
            {
                _petRepository.UpdateAsync(existingPet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingPet);
            }
            catch (Exception e)
            {
                return new PetResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public IEnumerable<Pet> GetPet(int userId)
        {
            return _petRepository.GetPet(userId);
        }

        public async Task<PetResponse> DeleteAsync(int id)
        {
            var existingPet = await _petRepository.FindAsync(id);
            if (existingPet == null)
                return new PetResponse("Pet not found.");
            try
            {
                _petRepository.Delete(existingPet);
                await _unitOfWork.CompleteAsync();
                return new PetResponse(existingPet);
            }
            catch (Exception e)
            {
                return new PetResponse($"An error occurred while deleting the pet: {e.Message}");
            }
        }

        public async Task<IEnumerable<Pet>> ListPublicationsGender(string gender)
        {
            return await _petRepository.ListPublicationsGender(gender);
        }

        public async Task<IEnumerable<Pet>> ListPublicationsType(string type)
        {
            return await _petRepository.ListPublicationsType(type);
        }

        public async Task<IEnumerable<Pet>> ListPublicationsAttention(string attention)
        {
            return await _petRepository.ListPublicationsAttention(attention);
        }

        public async Task<IEnumerable<Pet>> ListPublicationsGenderAttention(string gender, string attention)
        {
            return await _petRepository.ListPublicationsGenderAttention(gender, attention);

        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeAttention(string type, string attention)
        {
            return await _petRepository.ListPublicationsTypeAttention(type, attention);

        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeGender(string type, string gender)
        {
            return await _petRepository.ListPublicationsTypeGender(type, gender);

        }

        public async Task<IEnumerable<Pet>> ListPublicationsTypeGenderAttention(string type, string gender, string attention)
        {
            return await _petRepository.ListPublicationsTypeGenderAttention(type, gender, attention);

        }
    }
}

