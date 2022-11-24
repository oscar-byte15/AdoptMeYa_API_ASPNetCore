namespace GrupoWebBackend.DomainPublications.Resources
{
    public class PublicationFilter
    {
        public int Id { get; set; }
        public int PublicationId { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string DateTime { get; set; }
        public string Comment { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Attention { get; set; }
        public int Age { get; set; }
        public string Race { get; set; }
        public bool IsAdopted { get; set; }
        public bool IsPublished { get; set; } = false;
        public string Gender { get; set; }
        public string UrlToImage { get; set; }
    }
}