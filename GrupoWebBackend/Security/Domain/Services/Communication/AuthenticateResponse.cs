using GrupoWebBackend.Security.Domain.Entities;

namespace GrupoWebBackend.Security.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string UserNick { get; set; }
        public string? Ruc { get; set; }
        public string? Dni { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public int? DistrictId { get; set; }
        public string Token { get; set; }
        public string? UrlToImageBackground { get; set; }
        public string? UrlToImageProfile { get; set; }
        protected AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            UserNick = user.UserNick;
            Type = user.Type;
            Ruc = user.Ruc;
            Dni = user.Dni;
            Phone = user.Phone;
            Email = user.Email;
            DistrictId = user.DistrictId;
            Token = token;
            UrlToImageBackground = user.UrlToImageBackground;
            UrlToImageProfile = user.UrlToImageProfile;
        }

        protected AuthenticateResponse()
        {
            
        }
        
    }
}