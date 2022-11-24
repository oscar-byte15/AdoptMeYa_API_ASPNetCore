using GrupoWebBackend.DomainDistrict.Domain.Models;

namespace GrupoWebBackend.DomainDistrict.Domain.Services.Communications
{
    public class SaveDistrictResponse: BaseResponseA
    {

        public District District { get; private set; }
        public SaveDistrictResponse(District district) : this(true, string.Empty, district)
        {
        }
        public SaveDistrictResponse(bool succces, string message, District district) : base(succces, message)
        {
            District = district;
        }

        public SaveDistrictResponse(string message) : this(true, message, null)
        {
        }
    }
}