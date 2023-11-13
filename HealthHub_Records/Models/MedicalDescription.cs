using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHub_Records.Models
{
    public class MedicalDescription
    {
        [Key]
        
        public int Id { get; set; }
        public string Diabetic { get; set; } = string.Empty;
        [Display(Name = "Diabetic Detail")]
        public string DDiabetic { get; set; } = null;
        public string BloodPressure { get; set; } = string.Empty;
        [Display(Name = "BP Detail")]
        public string DBloodPressure { get; set; } = null;
        public string Allergies { get; set; } = string.Empty;
        [Display(Name = "Allergy Detail")]
        public string DAllergies { get; set; } = null;
        public string AnyMedication { get; set; } = string.Empty;
        [Display(Name = "AnyMedication Detail")]
        public string DAnyMedication { get; set; } = null;
        public string Asthematic { get; set; } = string.Empty;
        [Display(Name = "Asthematic Detail")]
        public string DAsthematic { get; set; } = null;
        public string SeriousInjury { get; set; } = string.Empty;
        [Display(Name = "SeriousInjury Detail")]
        public string DSeriousInjury { get; set; } = null;
        public string PreviousInjury{ get; set; } = string.Empty;
        [Display(Name = "PreviousInjury Detail")]
        public string DPreviousInjury { get; set; } = null;
        public string OtherProblem { get; set; } = string.Empty;
        [Display(Name = "OtherProblem Detail")]
        public string DOtherProblem { get; set; } = null;
        public decimal  Height{ get; set; }
        public decimal Weight { get; set; }
        public string BloodGroup { get; set; } = string.Empty;
        public int? userid { get; set; }
        [ForeignKey("userid")]
        public virtual Users Users { get; set; }
    }
}
