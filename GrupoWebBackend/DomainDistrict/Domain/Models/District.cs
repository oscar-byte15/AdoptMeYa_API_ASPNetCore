using System.Collections.Generic;
using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.DomainDistrict.Domain.Models
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public IList<User> User { get; set; } = new List<User>();
    }
}