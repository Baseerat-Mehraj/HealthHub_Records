using HealthHub_Records.ViewModels;
using HealthHub_Records.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub.Controllers
{
    public class PatientController : Controller
    {
        private readonly HealthhubDbContext db;
        public PatientController(HealthhubDbContext db)
        {
            this.db = db;
        }
        public IActionResult PatientsRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientRegistration(PatientRegistrationView obj)
        {
            Users log = new Users();
            log.username = obj.username;
            log.password = obj.password;
            log.email = obj.email;
            log.RoleId = 2;
            db.Users.Add(log);
            db.SaveChanges();

            PatientRegistration reg = new PatientRegistration();
            reg.firstname = obj.firstname;
            reg.lastname = obj.lastname;
            reg.address = obj.address;
            reg.city = obj.city;
            reg.state = obj.state;
            reg.dob = obj.dob;
            reg.gender = obj.gender;
            reg.phoneno = obj.phoneno;
            reg.userid = log.userid;
            db.PatientRegs.Add(reg);
            db.SaveChanges();
            ViewBag.Alert = "success";
            ViewBag.Message = "Patient Registered successfully!";
            return RedirectToAction("PatientsRegistration");
        }


        public IActionResult PatientDashboard()
        {
            return View();
        }


        public IActionResult PatientProfile()
        {

            // Retrieve the user ID from the session
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0; // Default to 0 if not found

            // Fetch user details based on the user ID from your data source
            // Replace this with code to retrieve user details from your database or wherever they are stored
            var user = db.PatientRegs.FirstOrDefault(r => r.userid == userId);

            // Pass the user details to the view
            return View(user);




        }

        public IActionResult EditProfile( int? id)
        {
            var result = db.PatientRegs.FirstOrDefault(r => r.patientid== id);
            return View(result);
          

        }
        [HttpPost]
        public IActionResult EditProfile(PatientRegistration reg, int? id)
        {
            var result = db.PatientRegs.FirstOrDefault(r => r.patientid == id);
            if (result != null)
            {

                result.address = reg.address;
                result.state = reg.state;
                result.city = reg.city;
                result.phoneno = reg.phoneno;
                db.SaveChanges();
                TempData["sucess"] = "Category updated successfull";
                return RedirectToAction("PatientProfile");

            }
            else
            {

                return NotFound("User doesnot edited");

            }


        }
        public IActionResult UploadReport()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadReport(Reports pdf)
        {
            int userIdd = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (pdf.file != null && pdf.file.Length > 0)
            {
                var fileName = Path.GetFileName(pdf.file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await pdf.file.CopyToAsync(stream);
                }

                //Save the file reference to the database
                Reports fileModel = new Reports();
                {
                    fileModel.FileName = string.Format("uploads/{0}", fileName);
                    fileModel.title = pdf.title;
                    fileModel.Description = pdf.Description;
                    fileModel.userid = userIdd;


                };

                db.Reports.Add(fileModel);
                int saved = await db.SaveChangesAsync();
                if (saved != 0)
                {
                    ViewBag.Alert = "success";
                    ViewBag.Message = "File uploaded successfully!";
                }
                else
                {
                    ViewBag.Alert = "error";
                    ViewBag.Message = "Error while uplaoding";
                }
            }

            return View(); // Redirect to a suitable action
        }

        public IActionResult ViewReport()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var user = db.Reports.Where(r => r.userid == userId).ToList();
            return View(user);
        }

       
        public IActionResult Download(int? id)
        {
            var fileModel = db.Reports.FirstOrDefault(r => r.userid == id);
            if (fileModel == null)
            {
                return NotFound();
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileModel.FileName);
            return PhysicalFile(filePath, "application/octet-stream", fileModel.FileName);

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