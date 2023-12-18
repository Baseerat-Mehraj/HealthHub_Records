using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.Models
{
    public class HospitalRegistration
    {
        [Key]
        public int Hospitalid { get; set; }
        [Display(Name = "Firstname")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Pincode")]
        public int pincode { get; set; }
        [Display(Name = "Phone No.")]
        [StringLength(20, ErrorMessage = "{0} must be atleast {2} and at max {1} characters long", MinimumLength = 7)]
        [RegularExpression(@"[+]+[0-9]{1,3}[- ]+[0-9]{9,}", ErrorMessage = "Invalid phone number format")]
        public int phoneno { get; set; }
        [Display(Name = "Licience No.")]
        public string licienceno { get; set; }

       
        public int? userid { get; set; }
        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}
