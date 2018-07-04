using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models
{
    interface LocationModel
    {
        
        int GetId();
        string GetLocType();
        void SetLocType(string value);

        string Destination();
    }
}
