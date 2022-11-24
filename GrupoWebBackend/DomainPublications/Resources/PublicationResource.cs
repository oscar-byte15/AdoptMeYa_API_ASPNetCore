namespace GrupoWebBackend.DomainPublications.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string dateTime { get; set; }
        public string comment { get; set; }
    }
}