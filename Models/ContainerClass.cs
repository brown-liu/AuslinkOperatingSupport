using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace AuslinkOperatingSupport.Models
{
    public class ContainerClass
    {

        [Key]
        [Display(Name ="Container Number")]
        [RegularExpression("^^[A-Z][A-Z][A-Z][A-Z][0-9]*$")]
        [StringLength(12,MinimumLength =5)]
        public String ContainerNumber { get; set; }




        [Display(Name ="O/F ETA")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OceanFreightETA { get; set; }




        [Display(Name = "Time To Yard")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TimeToYard { get; set; }




        [Required]
        [Display(Name ="Client Name")]
        public String ClientCompanyName { get; set; }



        [Display(Name = "Job Handler")]
        [Required]
        public String HandlerName { get; set; }



        [Display(Name ="Cartage Only")]
        public bool IfCartageOnly { get; set; }


        public bool IfRequireDelivery { get; set; }


        public bool IfRequireStorage { get; set; }


        public bool IfBookedCartage { get; set; }



        public bool IfEnteredCartonCloud { get; set; }



        public String ChargeFrom { get; set; }


        public bool IfExtraLeg { get; set; }



        [Display(Name ="Invoice Sent")]
        public bool IfInvoiced { get; set; }
    }
}
