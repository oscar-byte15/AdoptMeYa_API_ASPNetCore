using System.ComponentModel.DataAnnotations;

namespace GrupoWebBackend.DomainDistrict.Resources
{
    public class SaveDistrictResource
    {
        [Required]
        public string DistrictName { get; set; }
    }
}