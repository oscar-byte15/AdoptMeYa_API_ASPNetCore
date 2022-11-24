using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.DomainPublications.Domain.Services;
using GrupoWebBackend.Extensions;
using GrupoWebBackend.DomainPublications.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrupoWebBackend.DomainPublications.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PublicationsController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPublicationService _publicationService;
        public PublicationsController(IMapper mapper, IPublicationService publicationService)
        {
            _mapper = mapper;
            _publicationService = publicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary="Get All publications",Tags= new [] {"Publications"})]
        public async Task<IEnumerable<PublicationResource>> GetAllPublications()
        {
            var _publications = await _publicationService.ListPublicationAsync();
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(_publications);
            return resources;
        }
        [HttpPost]
        [SwaggerOperation(Summary="Post a publication",Tags= new [] {"Publications"})]
        public async Task<IActionResult> PostAsync([FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
            
                return BadRequest(ModelState.GetErrorMessages());
          
            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.SaveAsync(publication);

            if (!result.Success)
                return BadRequest(result.Message);


            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
        [HttpPut ("{id:int}")]
        [SwaggerOperation(Summary="Update a publication",Tags= new [] {"Publications"})]
        public async Task<IActionResult> PutAsync (int id, [FromBody] SavePublicationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var publication = _mapper.Map<SavePublicationResource, Publication>(resource);
            var result = await _publicationService.UpdateAsync(id, publication);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Publication, PublicationResource>(result.Resource);

            return Ok(categoryResource);
            
        }
        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary="Delete a specific publications",Tags= new [] {"Publications"})]
        public async Task<IActionResult>DeleteAsync(int id)
        {
            var result = await _publicationService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var publicationResource = _mapper.Map<Publication, PublicationResource>(result.Resource);
            return Ok(publicationResource);
        }
    }
}