using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_app_final.Shared.Domin
{
    public class Match
    {
        public int Id { get; set; }

        public virtual User User { get; set; }
        public int unmatch_ID { get; set; }
        public virtual Location location { get; set; }
        public DateTime match_timestamp { get; set; }

        public string image { get; set; }

        public string name { get; set; }







    }
}
