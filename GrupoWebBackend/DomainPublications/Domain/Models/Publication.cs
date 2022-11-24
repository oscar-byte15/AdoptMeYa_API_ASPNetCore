using System.Collections.Generic;
using GrupoWebBackend.DomainAdoptionsRequests.Domain.Models;
using GrupoWebBackend.DomainPets.Domain.Models;
using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.DomainPublications.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string DateTime { get; set; }
        public string Comment { get; set; }

        public IList<AdoptionsRequests> AdoptionsRequestsList { get; set; } = new List<AdoptionsRequests>();
        public IList<Pet> Pets { get; set; } = new List<Pet>();

    }
}