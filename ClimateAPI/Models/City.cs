namespace ClimateAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string NameAlbanian { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Population { get; set; }
        public string Region { get; set; } = string.Empty;
    }
}

