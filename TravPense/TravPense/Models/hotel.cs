namespace TravPense.Models
{
    public class hotel
    {
        public int id { get; set; }

        public string HotelName { get; set; }

        public string Standard { get; set; }
        public int PricePerDay { get; set; }
        public virtual Destination destination { get; set; }
    }
}