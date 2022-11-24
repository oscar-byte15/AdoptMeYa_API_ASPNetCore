using GrupoWebBackend.DomainAdvertisements.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Domain.Services.Communications;
using GrupoWebBackend.DomainPets.Domain.Models;

namespace GrupoWebBackend.DomainPets.Domain.Services.Communications
{
    public class PetResponse: BaseResponse<Pet>
    {
        public PetResponse(string message): base(message)
        {

        }
        public PetResponse(Pet resource): base(resource)
        {

        }
    }
}