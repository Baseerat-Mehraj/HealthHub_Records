using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.Models
{
    public class Users
    {

        [Key]
        public int userid { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string username { get; set; }=string.Empty;
        [Required(ErrorMessage = "This Field is Required")]
        public string password { get; set; }=string.Empty;
        [Required(ErrorMessage = "This Field is Required")]
        public string email { get; set; }
        public bool Request { get; set; } = true;
        public bool isactive { get; set; } = false;
        public int RoleId { get; set; }
    }
}
