using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models.DbViewModels
{
    public class HotelsView
    {
        [Key]
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Destination { get; set; }
        public string Contact { get; set; }
        public Int64 MinPrice { get; set; }
        public Int64 MaxPrice { get; set; }
    }
}
