using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AuslinkOperatingSupport.Models
{
    public class ClientClass
    {
        public int ID { get; set; }
        public String ClientContactPerson { get; set; }
        public String ClientContactNumber { get; set; }
        
        public String ClientCompanyName { get; set; }
        public String ClientRateSheetID { get; set; }

        public DateTime LastUpdateDate { get; set; }

        //public ICollection<ContainerClass> containers { get; set; }
    }
}
