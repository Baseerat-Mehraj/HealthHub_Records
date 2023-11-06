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
        [Display(Name = "Phone Number")]
        public int phoneno { get; set; }
        [Display(Name = "Licience Number")]
        public string licienceno { get; set; }
        public int? userid { get; set; }
        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}
