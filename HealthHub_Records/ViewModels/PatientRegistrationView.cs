using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class PatientRegistrationView
    {
        [Key]
        public int patientid { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string address { get; set; }

        public string state { get; set; }

        public string city { get; set; }

        public int pincode { get; set; }

        public DateTime dob { get; set; }

        public int phoneno { get; set; }

        public string gender { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string username { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        
        public string password { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmpassword { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string email { get; set; }
    }
}
