using System;
using System.ComponentModel.DataAnnotations;

namespace TravPense.Models
{
    public class activity
    {
        [Key]
        public int actid { get; set; }
        public string  ActivityName { get; set; }

        public TimeSpan Duration { get; set; }

        public int PricePerHour { get; set; }
        public virtual locationtype Loctype { get; set; }
    }
}