using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_app_final.Shared.Domin
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime Sub_DateStart { get; set; }
        public DateTime Sub_DateEnd { get; set; }
        public virtual Payment Payment_Id { get; set; }

        public virtual User User_Id { get; set; }
    }
}
