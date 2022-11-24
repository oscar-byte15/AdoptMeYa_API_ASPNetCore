using GrupoWebBackend.DomainAdvertisements.Domain.Services.Communications;
using GrupoWebBackend.DomainPublications.Domain.Models;

namespace GrupoWebBackend.DomainPublications.Domain.Services.Communications
{
    public class PublicationResponse:BaseResponse<Publication>
    {
        public PublicationResponse(string message): base(message)
        {

        }
        public PublicationResponse(Publication resource): base(resource)
        {

        }
    }
}