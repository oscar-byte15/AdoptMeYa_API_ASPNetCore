using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GrupoWebBackend.DomainAdoptionsRequests.Domain.Models;
using GrupoWebBackend.DomainAdoptionsRequests.Domain.Services;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainAdoptionsRequests.Resources;
using GrupoWebBackend.Extensions;
namespace GrupoWebBackend.DomainAdoptionsRequests.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    
    public class AdoptionsRequestsController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdoptionsRequestsService _adoptionsRequestsService;

        public AdoptionsRequestsController(IMapper mapper, IAdoptionsRequestsService adoptionsRequestsService)
        {
            _mapper = mapper;
            _adoptionsRequestsService = adoptionsRequestsService;
        }

        [HttpGet]
        public async Task<IEnumerable<AdoptionsRequestsResource>> GetAllAdoptionsRequests()
        {
            var _adoptionsRequests = await _adoptionsRequestsService.ListAdoptionsRequestsAsync();
            var resources = _mapper.Map<IEnumerable<AdoptionsRequests>, IEnumerable<AdoptionsRequestsResource>>(_adoptionsRequests);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveAdoptionsRequestsResource resource)
        {
    

           // if (!ModelState.IsValid)
             //   return BadRequest(ModelState.GetErrorMessages());
            var adoptionRequest = _mapper.Map<SaveAdoptionsRequestsResource, AdoptionsRequests>(resource);
            var result = await _adoptionsRequestsService.AddAsync(adoptionRequest);

        //    if (!result.Success)
          //      return BadRequest(result.Message);

            var adoptionRequestResource = _mapper.Map<AdoptionsRequests, AdoptionsRequestsResource>(result.AdoptionsRequests);
            return Ok(adoptionRequestResource);
        }
        
        
        
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAdoptionsRequestsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var adoptionRequest = _mapper.Map<SaveAdoptionsRequestsResource, AdoptionsRequests>(resource);
            var result = await _adoptionsRequestsService.UpdateAsync(id, adoptionRequest);

            if (!result.Success)
                return BadRequest(result.Message);

            var adoptionRequestResource = _mapper.Map<AdoptionsRequests, AdoptionsRequestsResource>(result.Resource);
            return Ok(adoptionRequestResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _adoptionsRequestsService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var adoptionRequestResource = _mapper.Map<AdoptionsRequests, AdoptionsRequestsResource>(result.Resource);
            return Ok(adoptionRequestResource);
        }

        [HttpGet("userIdFrom={useridfrom}")]
        public async Task<IEnumerable<AdoptionsRequests>> GetbyIdFrom(int useridfrom)
        {
                var result = await _adoptionsRequestsService.getAllUserFrom(useridfrom);
                return result;
        }
        
        [HttpGet("userIdAt={useridat}")]
        public async Task<IEnumerable<AdoptionsRequests>> GetbyIdAt(int useridat)
        {   
            var result = await _adoptionsRequestsService.getAllUserAt(useridat);
            return result;
        }
    }
}