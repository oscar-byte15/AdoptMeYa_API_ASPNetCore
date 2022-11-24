using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.DomainDistrict.Domain.Models;
using GrupoWebBackend.DomainDistrict.Domain.Services;
using GrupoWebBackend.Extensions;
using GrupoWebBackend.DomainDistrict.Resources;
using Microsoft.AspNetCore.Mvc;

namespace GrupoWebBackend.DomainDistrict.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class DistrictController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDistrictService _districtService;

        public DistrictController(IMapper mapper, IDistrictService districtService)
        {
            _mapper = mapper;
            _districtService = districtService;
        }

        [HttpGet]
        public Task<IEnumerable<District>> ListAsync()
        {
            return _districtService.ListAsync();
            // var resource = await _districtService.ListAsync();
            // var districts = _mapper.Map<IEnumerable<District>, IEnumerable<DistrictResource>>(resource);
            // return districts;
        }

        [HttpGet("{id:int}")]
        public async Task<District> FindAsync(int id)
        {
            var district = await _districtService.FindAsync(id);
            return district;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDistrictResource resource)
        {
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState.GetErrorMessages());
            //
            var pet = _mapper.Map<SaveDistrictResource, District>(resource);
            var result = await _districtService.AddAsync(pet);
            
            // if (!result.Succces)
            //     return BadRequest(result.Message);
            
            var petResource = _mapper.Map<District, DistrictResource>(result.District);
            return Ok(petResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync ([FromBody] SaveDistrictResource resource, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var district = _mapper.Map<SaveDistrictResource, District>(resource);
            var result = await _districtService.UpdateAsync(district, id);

            if (!result.Success)
                return BadRequest(result.Message);

            var districtResource = _mapper.Map<District, DistrictResource>(result.Resource);

            return Ok(districtResource);
            
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _districtService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var districtResourceResource = _mapper.Map<District, DistrictResource>(result.Resource);
            return Ok(districtResourceResource);
        }

    }
}