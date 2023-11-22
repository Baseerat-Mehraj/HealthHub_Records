using HealthHub_Records.Models;

namespace HealthHub_Records.ViewModels
{
    public class AllHospitalDetails
    {

        public IEnumerable<HospitalRegistration> Hospitals { get; set; }
    }
}
