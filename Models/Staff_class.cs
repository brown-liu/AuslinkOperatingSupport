using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuslinkOperatingSupport.Models
{
    public class Staff_class
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public String Name { get; set; }
        [Required]
        [StringLength(50)]
        public String UserName { get; set; }
        [Required]
        [StringLength(50)]
        public String Password { get; set; }
        public String MobileNumber { get; set; }
        [Range(0, 5)]
        public int AuthorityLevel { get; set; }
    }
}
