using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Data.Model
{
    public class Activityy
    {
        public int ActivityyId { get; set; }
        [Display(Name ="Activity")]
        public string ActivityName { get; set; }
        public int LocationId { get; set; }
    }
}
