using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_app_final.Shared.Domin
{
    public class Note
    {
        public string Message { get; }

        public DateTime Created { get; }

        public Note(string message)
        {
            Message = message;
            Created = DateTime.Now;
        }
    }
}
