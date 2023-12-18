using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class LoginUsersView
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
