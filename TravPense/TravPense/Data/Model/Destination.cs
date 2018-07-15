using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Data.Model
{
    public class Destination
    {
        public int DestinationId { get; set; }
        [Display(Name ="Destination")]
        public string DestName { get; set; }
        [NotMapped]
        public int LocationId { get; set; }
        [NotMapped]
        public int HotelId { get; set; }
        [NotMapped]
        public int ActivityId { get; set; }
        [NotMapped]
        public bool Checkboxanswer { get; set; }

        public ICollection<Location> locations { get; set; }
        public ICollection<Hotel> hotels { get; set; }

    }
}
