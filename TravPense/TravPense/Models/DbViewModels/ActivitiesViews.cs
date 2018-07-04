using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models.DbViewModels
{
    public class ActivitiesViews
    {
        [Key]
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string LocationType { get; set; }
        public string Duration { get; set; }
        public Int64 MyProperty { get; set; }
    }
}
