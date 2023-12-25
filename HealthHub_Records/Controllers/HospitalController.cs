
using HealthHub_Records.ViewModels;
using HealthHub_Records.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace HealthHub.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HealthhubDbContext db;
        private readonly INotyfService _notyf;
        public HospitalController(HealthhubDbContext db, INotyfService notyf)
        {
            this.db = db;
            _notyf = notyf;
        }
        public IActionResult HospitalRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HospitalRegistration(HospitalRegistrationView obj)
        {
            var result = db.Users.Any(u => u.email == obj.email);

            if (result)
            {

                _notyf.Error("Email already exists Try another email!");
                return RedirectToAction("HospitalRegistration");

            }
            else if (ModelState.IsValid && obj.confirmpassword == obj.password)
            {
                Users log = new Users();
                log.username = obj.username;
                log.password = obj.password;
                log.email = obj.email;
                log.RoleId = 3;
                log.Request = true;
                
                db.Users.Add(log);
                db.SaveChanges();

                HospitalRegistration reg = new HospitalRegistration();
                reg.Name = obj.Name;
                reg.address = obj.address;
                reg.licienceno = obj.licienceno;
                reg.city = obj.city;
                reg.state = obj.state;
                reg.pincode = obj.pincode;
                reg.phoneno = obj.phoneno;
                reg.userid = log.userid;
                db.HospitalRegs.Add(reg);
                db.SaveChanges();
                _notyf.Success("Hospital Registered successfully!");
                return RedirectToAction("HospitalRegistration");
            }
            else
            {
                _notyf.Error("Something went wrong Try again!");
                return RedirectToAction("HospitalRegistration");

            }
        }  

        public IActionResult HospitalDashboard()
        {
            return View();
        }
        public IActionResult PatientD(int? id)
        {

            var result = db.PatientRegs.FirstOrDefault(r => r.userid == id);


            return View(result);
        }
        public IActionResult SearchPatient()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchPatient(SearchPatientView search)
        {
            
            var users = db.Users.FirstOrDefault(r => r.userid == search.Userid && r.isactive==true);
            if (users == null)
            {

                _notyf.Success("User doesnot exixt");
                return View();

            }
            else {

                return RedirectToAction("PatientD", new { id = users.userid });


                

            }
          

        }
       
        public IActionResult PatientReports(int? id)
        {
            ViewBag.UId =id;
            var result = db.Reports.Where(r => r.userid == id).ToList();


            return View(result);
        }
        public IActionResult MedicalD(int? id)
        {

            var result = db.MedicalDescription.FirstOrDefault(r => r.userid == id);
            if (result != null)
            {

                return View(result);
            }
            else {

                _notyf.Error("User doesnot have Submited any details Yet!");
                return RedirectToAction("PatientD", new { id = id });
            }

          
        }

        public IActionResult HospitalProfile()
        {

            
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; 

            var user = db.HospitalRegs.FirstOrDefault(r => r.userid == userId);

          
            return View(user);




        }

        public IActionResult EditHospitalProfile(int? id)
        {
            var result = db.HospitalRegs.FirstOrDefault(r => r.Hospitalid == id);
            return View(result);


        }
        [HttpPost]
        public IActionResult EditHospitalProfile(HospitalRegistration reg, int? id)
        {
            var result = db.HospitalRegs.FirstOrDefault(r => r.Hospitalid == id);
            if (result != null)
            {

                result.address = reg.address;
                result.state = reg.state;
                result.city = reg.city;
                result.phoneno = reg.phoneno;
                db.SaveChanges();
                _notyf.Success("Profile updated successfully!");
                return RedirectToAction("HospitalProfile");

            }
            else
            {

                return NotFound("User doesnot edited");

            }


        }
       


        public IActionResult Appoinment(int? id)
        {
            int userIdd = HttpContext.Session.GetInt32("UserId") ?? 0;
            ViewBag.PatientId = id;
            ViewBag.HospitalId=userIdd;

            var result = db.HospitalRegs.FirstOrDefault(r => r.userid == userIdd);
            if (result != null)
            {
                ViewBag.HospitalHome = result.Name +" " +result.address +" "+ result.state+" "+result.city;
                return View();
            }
            else {

               
                return NotFound("User not there");
            
            }
             
        }

        [HttpPost]
        public IActionResult Appoinment( Appoinment app)
        {
            try
            {
                db.Appoinment.Add(app);
                db.SaveChanges();
                _notyf.Success("Patient appoinment set successfully!");
                return RedirectToAction("HospitalPatientAppoinments", new { id = app.userid });
            }
            catch (Exception)
            {
              
                return NotFound("Error"); 
            }

        }
        public IActionResult HospitalPatientAppoinments(int? id)
        {
            ViewBag.UId=id;
            var result = db.Appoinment.Where(r => r.userid == id).ToList();
            return View(result);
        }
    }
}
