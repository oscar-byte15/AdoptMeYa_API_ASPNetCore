using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Resources;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.DomainPublications.Domain.Services;
using GrupoWebBackend.DomainPublications.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrupoWebBackend.DomainPublications.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/users/{userId}/publications")]
    public class UserPublicationController
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public UserPublicationController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }
        [HttpGet]
        [SwaggerOperation(Summary="Get All publications by User",Tags= new [] {"Publications"})]
        public async Task<IEnumerable<PublicationResource>> GetAllPublicationsByUserIdAsync(int userId)
        {
            var advertisements= await _publicationService.ListByUserId(userId);
            var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(advertisements);
            return resources;
        }
    }
}