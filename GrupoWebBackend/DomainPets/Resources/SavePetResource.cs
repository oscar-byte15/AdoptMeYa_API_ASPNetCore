using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GrupoWebBackend.DomainPets.Resources
{
    public class SavePetResource
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Attention { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Race {get; set; }
        public bool IsAdopted {get; set; }
        [Required]
        public int UserId { get; set; }
        
        public int? PublicationId { get; set; }
        
        public bool IsPublished { get; set; } = false;
        public string Gender { get; set; }
        public string UrlToImage { get; set; }
    }
}