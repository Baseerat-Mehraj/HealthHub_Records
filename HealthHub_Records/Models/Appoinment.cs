using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHub_Records.Models
{
    public class Appoinment
    {
        [Key]
        public int AppoinmentId{ get; set; }
        [Display(Name = "Hospital")]
        public string HospitalDetails { get; set; }
        public  DateTime Date{ get; set; }
        public  string Disease { get; set; }    

        public string Description { get; set; }
        public string Medicines { get; set; }
        public string Advice { get; set; }

        public DateTime NextAppoinment { get; set; }
        [Display(Name = "Doctor")]
        public string DoctorName { get; set;}
        public string DoctorContact { get; set;}
     
        public int? userid { get; set; }
        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}
