using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravPense.Models
{
    public class locationtype
    {
        [Key]
        public int locid { get; set; }
        public string Loctype { get; set; }
        public virtual Destination destination  { get; set; }
        public virtual ICollection<activity> activities { get; set; }

    }
}