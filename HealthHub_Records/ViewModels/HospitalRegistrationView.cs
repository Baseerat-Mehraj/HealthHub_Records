using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class HospitalRegistrationView
    {
        [Key]
        public int Hospitalid { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public int pincode { get; set; }
        public long phoneno { get; set; }
        public string licienceno { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string confirmpassword { get; set; }
        public string email { get; set; }
    }
}
