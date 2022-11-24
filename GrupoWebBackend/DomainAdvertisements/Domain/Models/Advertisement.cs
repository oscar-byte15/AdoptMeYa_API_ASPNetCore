using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.DomainAdvertisements.Domain.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public string UrlToImage { get; set; }
        public bool Promoted { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        
      
    }
}