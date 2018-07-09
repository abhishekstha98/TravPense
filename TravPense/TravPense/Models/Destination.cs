using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class Destination
    {
        public int id { get; set; }
        public string  DestinationName { get; set; }

        public virtual ICollection<loctype> Loctypes { get; set; }
        public virtual ICollection<hotel> Hotels { get; set; }
    }
}
