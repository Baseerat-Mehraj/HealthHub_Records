
using AspNetCoreHero.ToastNotification.Abstractions;
using HealthHub_Records.Models;
using HealthHub_Records.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthHub_Records.Controllers
{
    public class AdminController : Controller
    {
        private readonly HealthhubDbContext db;
        private readonly INotyfService _notyf;
        public AdminController(HealthhubDbContext db, INotyfService notyf)
        {
            this.db = db;
            _notyf = notyf;
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult GetAllPatients()
        {
          
         
            var patients = db.PatientRegs.Include(p => p.Users).ToList();

           
            AllPatientDetails obj = new AllPatientDetails
            {
                Patients = patients
            };

            return View(obj);
           
        }

        public IActionResult GetAllHospitals()
        {
            var hospitals = db.HospitalRegs.Include(p => p.Users).ToList();

            AllHospitalDetails obj = new AllHospitalDetails
            {
                Hospitals=hospitals
            };
            return View(obj);

        }
        public IActionResult Active(int? id)
        {
            var result = db.Users.FirstOrDefault(r => r.userid == id);
            if (result != null)
            {

                result.isactive = true;
                db.Users.Update(result);
                db.SaveChanges();
                
                _notyf.Success("User Activated Successfully");
                return RedirectToAction("AdminDashboard");

            }
            else
            {

                return NotFound("User not found");


            }
        }
        public IActionResult Inactive(int? id)
        {
            var result = db.Users.FirstOrDefault(r => r.userid == id);
            if (result != null)
            {

                result.isactive = false;
                db.Users.Update(result);
                db.SaveChanges();
                _notyf.Success("User Deactivated Successfully");
                return RedirectToAction("AdminDashboard");

            }
            else
            {

                return NotFound("User not found");


            }



        }
      
        public IActionResult Feedback()
        {
            IEnumerable<Contact> objCategoryList = db.Contacts;
            return View(objCategoryList);
        }
     
    }
}
