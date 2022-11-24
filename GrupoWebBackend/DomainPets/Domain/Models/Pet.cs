using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using GrupoWebBackend.DomainPublications.Domain.Models;
using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.DomainPets.Domain.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Attention { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public bool IsAdopted { get; set; }
        public bool IsPublished { get; set; } = false;
        public string Gender { get; set; }

        public string UrlToImage { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [AllowNull]
        public int? PublicationId { get; set; }
        public Publication Publication { get; set; }
    }
}
