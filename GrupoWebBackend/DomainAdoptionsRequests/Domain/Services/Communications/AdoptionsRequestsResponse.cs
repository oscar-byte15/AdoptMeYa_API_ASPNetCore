using GrupoWebBackend.DomainAdoptionsRequests.Domain.Models;
using GrupoWebBackend.DomainAdvertisements.Domain.Services.Communications;
namespace GrupoWebBackend.DomainAdoptionsRequests.Domain.Services.Communications
{
    public class AdoptionsRequestsResponse:BaseResponse<AdoptionsRequests>
    {
        public AdoptionsRequestsResponse(string message) : base(message)
        {
            
        }

        public AdoptionsRequestsResponse(AdoptionsRequests resource) : base(resource)
        {
            
        }
    }
}