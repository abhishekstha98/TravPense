using System.Collections.Generic;

namespace TravPense.Models
{
    public class loctype
    {
        public int id { get; set; }
        public string Loctype { get; set; }
        public virtual Destination destination  { get; set; }
        public virtual ICollection<activity> activities { get; set; }

    }
}