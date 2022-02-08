using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_app_final.Shared.Domin
{
    public class Location
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
        public string Location_Gps { get; set; }
    }
}
