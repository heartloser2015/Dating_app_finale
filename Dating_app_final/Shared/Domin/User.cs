using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dating_app_final.Shared.Domin
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name does not meet length requirements")] 
        public string username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        [EmailAddress]
        public string email { get; set; }

        public string image { get; set; }
        public string password { get; set; }
        public string gender { get; set; }

        public DateTime Birth { get; set; }
        public string Status { get; set; }
        public string GenderP { get; set; }
        public string Location { get; set; }
        public string Like { get; set; }
        public string Superlike { get; set; }
    }
}
