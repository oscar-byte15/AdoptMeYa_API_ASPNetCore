using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrupoWebBackend.DomainDistrict.Domain.Models;
using GrupoWebBackend.DomainDistrict.Domain.Repositories;
using GrupoWebBackend.DomainDistrict.Domain.Services;
using GrupoWebBackend.DomainDistrict.Domain.Services.Communications;
using GrupoWebBackend.Shared.Domain.Repositories;

namespace GrupoWebBackend.DomainDistrict.Services
{
    public class DistrictService: IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork)
        {
            _districtRepository = districtRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _districtRepository.ListAsync();
        }



        public async Task<District> FindAsync(int id)
        {
            return await _districtRepository.FindAsync(id);
        }
        
        public async Task<SaveDistrictResponse> AddAsync(District district)
        {
            try
            {
                await _districtRepository.AddAsync(district);
                await _unitOfWork.CompleteAsync();
                return new SaveDistrictResponse(district);
            }
            catch (Exception e)
            {
                return new SaveDistrictResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<DistrictResponse> UpdateAsync(District district, int id)
        {
            var existingDistrict = await _districtRepository.FindAsync(id);
            if (existingDistrict == null)
                return new DistrictResponse("District not found");
            existingDistrict.DistrictName = district.DistrictName;

            try
            {
                _districtRepository.UpdateAsync(existingDistrict);
                await _unitOfWork.CompleteAsync();
                return new DistrictResponse(existingDistrict);
            }
            catch (Exception e)
            {
                return new DistrictResponse($"An error occurred while saving District: {e.Message}");
            }
        }

        public async Task<DistrictResponse> DeleteAsync(int id)
        {
            var existingDistrict = await _districtRepository.FindAsync(id);
            if (existingDistrict == null)
                return new DistrictResponse("District not found.");
            try
            {
                _districtRepository.Delete(existingDistrict);
                await _unitOfWork.CompleteAsync();
                return new DistrictResponse(existingDistrict);
            }
            catch (Exception e)
            {
                return new DistrictResponse($"An error occurred while deleting the pet: {e.Message}");
            }
        }
    }
}

