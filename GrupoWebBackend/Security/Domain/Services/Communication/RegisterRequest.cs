using System.ComponentModel.DataAnnotations;

namespace GrupoWebBackend.Security.Domain.Services.Communication
{
    public class RegisterRequest
    {
        public string? Name { get; set; }
        [Required]
        public string Pass { get; set; }
        [Required]
        public string Type { get; set; }
        
        public string? LastName { get; set; }
        [Required]
        public string UserNick { get; set; }
        public string? Ruc { get; set; }
        public string? Dni { get; set; }
        public string? Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public int? DistrictId { get; set; }
        public string? UrlToImageBackground { get; set; }
        public string? UrlToImageProfile { get; set; }
    }
}