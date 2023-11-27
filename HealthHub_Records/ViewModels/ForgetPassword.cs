using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class ForgetPassword
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
