
using HealthHub_Records.Models;
using HealthHub_Records.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub_Records.Controllers
{
    public class AdminController : Controller
    {
        private readonly HealthhubDbContext db;
        public AdminController(HealthhubDbContext db)
        {
            this.db = db;   
            
        }
        public IActionResult AdminDashboard()
        {
            return View();
        }
        public IActionResult GetAllPatients()
        {
            IEnumerable<PatientRegistration> objCategoryList = db.PatientRegs;
            return View(objCategoryList);
           
        }

        public IActionResult GetAllHospitals()
        {
            IEnumerable<HospitalRegistration> objCategoryList = db.HospitalRegs;
            return View(objCategoryList);

        }
        public IActionResult Active(int? id)
        {
            var result = db.Users.FirstOrDefault(r => r.userid == id);
            if (result != null)
            {

                result.isactive = true;
                db.Users.Update(result);
                db.SaveChanges();
                TempData["sucess"] = "Category updated successfull";
                return RedirectToAction("GetAllPatients");

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
                TempData["sucess"] = "Category updated successfull";
                return RedirectToAction("GetAllPatients");

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
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordView v)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var result = db.Users.FirstOrDefault(r => r.userid == userId && r.password == v.OldPassword);
            if (result != null)
            {

                result.password = v.NewPassword;
                db.SaveChanges();
                return RedirectToAction("Logout");


            }
            else
            {
                return NotFound("Password donot match");

            }

        }



    }
}
