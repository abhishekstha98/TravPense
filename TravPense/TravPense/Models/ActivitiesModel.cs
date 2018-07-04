using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    public class ActivitiesModel:LocationModel
    {
        [Key]
        public int ActivityID { get; set; }

        public string ActivityName { get; set; }

        public string Loctype { get { return Loctype; }}

        public int Price { get; set; }

        public string Destination()
        {
            throw new NotImplementedException();
        }

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
    }
}
