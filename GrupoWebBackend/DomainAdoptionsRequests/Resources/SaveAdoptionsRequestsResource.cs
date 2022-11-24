using System.ComponentModel.DataAnnotations;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.Security.Domain.Entities;
using System.Diagnostics.CodeAnalysis;
namespace GrupoWebBackend.DomainAdoptionsRequests.Resources
{
    public class SaveAdoptionsRequestsResource
    {
        [Required]
        public string Message { get; set; }
        
        [Required]
        public string Status { get; set; }
        
        [Required]
        public int UserIdFrom { get; set; }
        
        [Required]
        public int UserIdAt { get; set; }
          
        public int? PublicationId { get; set; }

    }
}