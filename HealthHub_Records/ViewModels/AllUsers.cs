using HealthHub_Records.Models;

namespace HealthHub_Records.ViewModels
{
    public class AllUsers
    {
        public IEnumerable<PatientRegistration> Patients { get; set; }
        public IEnumerable<HospitalRegistration> Hospitals { get; set; }
    }
}
