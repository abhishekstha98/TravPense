using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class Location
    {
        [Key]
        public int locid { get; set; }
        public string Loctype { get; set; }
        public string Destination { get; set; }
    }
}
