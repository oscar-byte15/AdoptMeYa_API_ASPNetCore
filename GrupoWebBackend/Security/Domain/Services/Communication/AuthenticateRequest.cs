using System.ComponentModel.DataAnnotations;

namespace GrupoWebBackend.Security.Domain.Services.Communication
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserNick { get; set; }
        [Required]
        public string Pass { get; set; }
    }
}