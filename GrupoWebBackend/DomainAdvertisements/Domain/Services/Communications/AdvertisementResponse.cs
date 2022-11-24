using GrupoWebBackend.DomainAdvertisements.Domain.Models;

namespace GrupoWebBackend.DomainAdvertisements.Domain.Services.Communications
{
    public class AdvertisementResponse:BaseResponse<Advertisement>
    {
        public AdvertisementResponse(string message): base(message)
        {

        }
        public AdvertisementResponse(Advertisement resource): base(resource)
        {

        }
    }
}