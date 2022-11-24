using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.DomainAdoptionsRequests.Resources
{
    public class AdoptionsRequestsResource
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int UserIdFrom { get; set; }
        public int UserIdAt { get; set; }
        public int PublicationId { get; set; }


    }
}