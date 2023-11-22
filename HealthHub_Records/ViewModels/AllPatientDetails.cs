using HealthHub_Records.Models;

namespace HealthHub_Records.ViewModels
{
    public class AllPatientDetails
    {

        public IEnumerable<PatientRegistration> Patients { get; set; }
    }
}

