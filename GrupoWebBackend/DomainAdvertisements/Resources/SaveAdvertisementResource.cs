using System.ComponentModel.DataAnnotations;

namespace GrupoWebBackend.DomainAdvertisements.Resources
{
    public class SaveAdvertisementResource
    {
        [Required]
        public string DateTime { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public string UrlToImage { get; set; }
        [Required]
        public bool Promoted { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}