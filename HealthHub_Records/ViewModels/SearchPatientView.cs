using System.ComponentModel.DataAnnotations;

namespace HealthHub_Records.ViewModels
{
    public class SearchPatientView
    {
        [Key]
        public int id { get; set; }
        public int Userid { get; set; }
    }
}
