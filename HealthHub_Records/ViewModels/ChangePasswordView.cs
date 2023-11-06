using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class ChangePasswordView
    {
        [Key]
        public int Userid { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
