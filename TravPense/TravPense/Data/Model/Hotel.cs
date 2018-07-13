using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Data.Model
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [Display(Name ="Hotel Name")]
        public string HotName { get; set; }
        public int Price { get; set; }
        public int DestinationId { get; set; }


    }
}
