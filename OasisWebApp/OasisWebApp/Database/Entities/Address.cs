namespace OasisWebApp.Database.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string MetroStation { get; set; }
        public string District { get; set; }
        public int CinemaId { get; set; }
    }
}
