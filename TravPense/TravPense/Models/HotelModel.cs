using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class HotelModel
    {
        [Key]
        public int Hotelid { get; set; }
        public string HotelName { get; set; }

        [ForeignKey("Location")]
        public string Destination { get; set; }

        public string Contact { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

    }
}
