namespace GrupoWebBackend.Security.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string? Name { get; set; }
        public string LastName { get; set; }
        public string UserNick { get; set; }
        public string? Ruc { get; set; }
        public string? Dni { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public int? DistrictId { get; set; }
        public string? UrlToImageBackground { get; set; }
        public string? UrlToImageProfile { get; set; }
    }
}