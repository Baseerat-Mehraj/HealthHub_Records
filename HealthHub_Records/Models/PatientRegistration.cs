using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HealthHub_Records.Models
{
    public class PatientRegistration
    {
        [Key]
        public int patientid { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This Field is Required")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "State")]
        public string state { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
       
        [Display(Name = "DOB")]
        public DateTime dob { get; set; }
        [Display(Name = "Phone No.")]
        public int phoneno { get; set; }
        
        [Display(Name = "Gender")]
        public string gender { get; set; }

        public int? userid { get; set; }
        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}
