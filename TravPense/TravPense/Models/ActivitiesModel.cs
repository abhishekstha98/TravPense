using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class ActivitiesModel
    {
        [Key]
        public int ActivityID { get; set; }

        public string ActivityName { get; set; }

        [ForeignKey("Location")]
        public string Loctype { get; set; }

        public int Price { get; set; }

       
    }
}
