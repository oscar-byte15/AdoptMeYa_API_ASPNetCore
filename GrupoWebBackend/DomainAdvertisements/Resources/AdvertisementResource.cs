namespace GrupoWebBackend.DomainAdvertisements.Resources
{
    public class AdvertisementResource
    {
        public int Id { get; set; }
        public string DateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Discount { get; set; }
        public string UrlToImage { get; set; }
        public bool Promoted { get; set; }
    }
}