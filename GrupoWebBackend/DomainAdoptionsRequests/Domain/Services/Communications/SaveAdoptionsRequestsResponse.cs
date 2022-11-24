using GrupoWebBackend.DomainAdoptionsRequests.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Services.Communications;

namespace GrupoWebBackend.DomainAdoptionsRequests.Domain.Services.Communications
{
    public class SaveAdoptionsRequestsResponse:BaseResponseA
    {
        public AdoptionsRequests AdoptionsRequests { get; private set; }

        public SaveAdoptionsRequestsResponse(AdoptionsRequests adoptionsRequests) : this(true, string.Empty,
            adoptionsRequests)
        {
            
        }

        public SaveAdoptionsRequestsResponse(bool succces, string message, AdoptionsRequests adoptionsRequests) : base(succces,
            message)
        {
            AdoptionsRequests = adoptionsRequests;
        }

        public SaveAdoptionsRequestsResponse(string message) : this(true, message, null)
        {
            
        }
    }
}