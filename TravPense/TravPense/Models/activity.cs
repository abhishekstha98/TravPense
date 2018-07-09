using System;

namespace TravPense.Models
{
    public class activity
    {
        public int id { get; set; }
        public string  ActivityName { get; set; }

        public DateTime Duration { get; set; }

        public int PricePerHour { get; set; }
        public virtual loctype Loctype { get; set; }
    }
}