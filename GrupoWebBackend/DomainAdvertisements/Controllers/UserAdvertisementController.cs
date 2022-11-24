using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Domain.Services;
using GrupoWebBackend.DomainAdvertisements.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GrupoWebBackend.DomainAdvertisements.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/Users/{userId}/Advertisements")]
    public class UserAdvertisementController
    {
        private readonly IAdvertisementService _advertisementService;
        private readonly IMapper _mapper;

        public UserAdvertisementController(IAdvertisementService advertisementService,IMapper mapper)
        {
            _advertisementService = advertisementService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary="Get All Advertisements by User",Tags= new [] {"Advertisements"})]
        public async Task<IEnumerable<AdvertisementResource>> GetAllAdvertisementsByUserIdAsync(int userId)
        {
            var advertisements= await _advertisementService.ListByUserId(userId);
            var resources = _mapper.Map<IEnumerable<Advertisement>, IEnumerable<AdvertisementResource>>(advertisements);
            return resources;
        }
    }
}