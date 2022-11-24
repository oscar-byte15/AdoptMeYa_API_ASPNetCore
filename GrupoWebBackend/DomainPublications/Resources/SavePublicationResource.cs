using System.ComponentModel.DataAnnotations;

namespace GrupoWebBackend.DomainPublications.Resources
{
    public class SavePublicationResource
    {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int UserId {get; set; }
        [Required] 
        public string DateTime { get; set; }
        [Required]
        public string Comment { get; set; }

        

       
    }
}