using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class HotelModel:LocationModel
    {
        [Key]
        public int Hotelid { get; set; }
        public string HotelName { get; set; }
        [ForeignKey("LocationModel")]
        public string Destination { get; set; }

        public string Contact { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public string GetLocType()
        {
            throw new NotImplementedException();
        }

        public void SetLocType(string value)
        {
            throw new NotImplementedException();
        }

        string LocationModel.Destination()
        {
            throw new NotImplementedException();
        }
    }
}
