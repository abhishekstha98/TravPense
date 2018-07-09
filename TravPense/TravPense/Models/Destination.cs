using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class Destination
    {
        [Key]
        public int destid { get; set; }
        public string  DestinationName { get; set; }

        public virtual ICollection<locationtype> Loctypes { get; set; }
        public virtual ICollection<hotel> Hotels { get; set; }
    }
}
