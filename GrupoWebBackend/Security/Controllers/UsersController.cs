using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;
using GrupoWebBackend.DomainPets.Resources;
using GrupoWebBackend.Extensions;
using Microsoft.AspNetCore.Mvc;
using GrupoWebBackend.Security.Authorization.Attributes;
using GrupoWebBackend.Security.Domain.Entities;
using GrupoWebBackend.Security.Domain.Services;
using GrupoWebBackend.Security.Domain.Services.Communication;
using GrupoWebBackend.Security.Resources;
using Swashbuckle.AspNetCore.Annotations;

namespace GrupoWebBackend.Security.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("auth/sign-up")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _userService.RegisterAsync(request);
            return Ok(new { message = "Registration successful" });
        }
        
        [HttpGet]
        [SwaggerOperation(Summary="Get All Users",Tags= new [] {"Users"})]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.ListAsync();
            
            var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
            return Ok(resources);
        }
        
        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary="Get User",Tags= new [] {"User"})]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            
            var resource = _mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }
        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary="Put User",Tags= new [] {"User"})]
        public async Task<IActionResult> Put([FromBody] RegisterRequest resource, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<RegisterRequest, User>(resource);
            var result = await _userService.UpdateUser(user, id);

            if (!result.Success)
                return BadRequest(result.Message);

            var petResource = _mapper.Map<User, RegisterRequest>(result.Resource);

            return Ok(petResource);
        }
    }   
}