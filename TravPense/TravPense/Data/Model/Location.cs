using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Data.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        [Display(Name ="Location Type")]
        public string LocType { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }

        public ICollection<Activityy> activityys { get; set; }
    }
}
