
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
            var patients = db.PatientRegs.ToList();
            var hospital = db.HospitalRegs.ToList();
            var result = db.Users.Where(r=>r.Request==true).ToList();
            ViewBag.TotalPatients=patients.Count;
            ViewBag.TotalHospitals = hospital.Count;
            ViewBag.TotalRequests=result.Count;


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

        public IActionResult Request()
        {
            var patients = db.PatientRegs.Include(p => p.Users).Where(p => p.Users.Request == true).ToList();
            var hospitals = db.HospitalRegs.Include(h => h.Users).Where(h => h.Users.Request == true).ToList();
            if (patients.Count == 0 && hospitals.Count == 0)
            {

                _notyf.Success("No Request Yet!");

                return RedirectToAction("AdminDashboard");
            }
            else { 

            var viewModel = new AllUsers
            {
                Patients = patients,

                Hospitals = hospitals
            };
         
            return View(viewModel);
            }
        }

        public IActionResult AcceptRequest(int? id)
        {
            var result = db.Users.FirstOrDefault(r => r.userid == id);
            if (result != null)
            {
                result.Request = false;
                result.isactive = true;
                db.Users.Update(result);
                db.SaveChanges();

                _notyf.Success("Request Accepted");
                return RedirectToAction("AdminDashboard");

            }
            else
            {

               
                return RedirectToAction("AdminDashboard");


            }
        }


    }
}
