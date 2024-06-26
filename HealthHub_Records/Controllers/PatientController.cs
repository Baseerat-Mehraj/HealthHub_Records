﻿using HealthHub_Records.ViewModels;
using HealthHub_Records.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace HealthHub.Controllers
{
    public class PatientController : Controller
    {
        private readonly HealthhubDbContext db;
        private readonly INotyfService _notyf;
        public PatientController(HealthhubDbContext db, INotyfService notyf)
        {
            this.db = db;
            _notyf = notyf;
        }
        public IActionResult PatientsRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PatientRegistration(PatientRegistrationView obj)
        {
            var result = db.Users.Any(u => u.email == obj.email);

            if (result)
            {

                _notyf.Error("Email already exists Try another email!");
                return RedirectToAction("PatientsRegistration");

            }
            else if (ModelState.IsValid && obj.confirmpassword == obj.password)
            {
                Users log = new Users();
                log.username = obj.username;
                log.password = obj.password;
                log.email = obj.email;
                log.RoleId = 2;
                log.Request = true;
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
                _notyf.Success("Patient Registered successfully!");
                return RedirectToAction("PatientsRegistration");
            }
            else {

                _notyf.Error("Something went wrong Try again!");
                return RedirectToAction("PatientsRegistration");

            }



        }


        public IActionResult PatientDashboard()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var user = db.Reports.Where(r => r.userid == userId).ToList();
            var result = db.Appoinment.Where(r => r.userid == userId).ToList();
            ViewBag.TotalReports = user.Count;
            ViewBag.TotalAppoinments = result.Count;
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
                _notyf.Success("Patient updated successfully!");
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
                    fileModel.Title = pdf.Title;
                    fileModel.Description = pdf.Description;
                    fileModel.userid = userIdd;


                };

                db.Reports.Add(fileModel);
                int saved = await db.SaveChangesAsync();
                if (saved != 0)
                {
                    _notyf.Success("File Uploaded successfully!");
                }
                else
                {
                    _notyf.Error("Something went wrong!");
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
     

        public IActionResult MedicalDescription() {

            return View();
        }
        [HttpPost]
        public IActionResult MedicalDescription(MedicalDescription obj)
        {
            int userIdd = HttpContext.Session.GetInt32("UserId") ?? 0;

            var med = db.MedicalDescription.FirstOrDefault(r=>r.userid==userIdd);
            if (med != null)
            {

                med.Diabetic = obj.Diabetic;
                med.DDiabetic = obj.DDiabetic;
                med.BloodPressure = obj.BloodPressure;
                med.DBloodPressure = obj.DBloodPressure;
                med.Allergies = obj.Allergies;
                med.DAllergies = obj.DAllergies;
                med.AnyMedication = obj.AnyMedication;
                med.DAnyMedication = obj.DAnyMedication;
                med.Asthematic = obj.Asthematic;
                med.DAsthematic = obj.DAsthematic;
                med.SeriousInjury = obj.SeriousInjury;
                med.DSeriousInjury = obj.DSeriousInjury;
                med.PreviousInjury = obj.PreviousInjury;
                med.DPreviousInjury = obj.DPreviousInjury;
                med.OtherProblem = obj.OtherProblem;
                med.DOtherProblem = obj.DOtherProblem;
                med.Height = obj.Height;
                med.Weight = obj.Weight;
                med.BloodGroup = obj.BloodGroup;
            

                db.MedicalDescription.Update(med);
                db.SaveChanges();
                _notyf.Success("Patient MedicalDetails Updated successfully!");
                return RedirectToAction("PatientDashboard");
            }
            else {

                MedicalDescription me=new MedicalDescription();
                me.Diabetic = obj.Diabetic;
                me.DDiabetic = obj.DDiabetic;
                me.BloodPressure = obj.BloodPressure;
                me.DBloodPressure = obj.DBloodPressure;
                me.Allergies = obj.Allergies;
                me.DAllergies = obj.DAllergies;
                me.AnyMedication = obj.AnyMedication;
                me.DAnyMedication = obj.DAnyMedication;
                me.Asthematic = obj.Asthematic;
                me.DAsthematic = obj.DAsthematic;
                me.SeriousInjury = obj.SeriousInjury;
                me.DSeriousInjury = obj.DSeriousInjury;
                me.PreviousInjury = obj.PreviousInjury;
                me.DPreviousInjury = obj.DPreviousInjury;
                me.OtherProblem = obj.OtherProblem;
                me.DOtherProblem = obj.DOtherProblem;
                me.Height = obj.Height;
                me.Weight = obj.Weight;
                me.BloodGroup = obj.BloodGroup;
                me.userid = userIdd;
                db.MedicalDescription.Add(me);
                db.SaveChanges();
                _notyf.Success("Patient Medical Details Added Successfully!");
                return RedirectToAction("PatientDashboard");



            }
           
        }

        public IActionResult PatientAppoinments()
        {
            int id = HttpContext.Session.GetInt32("UserId") ?? 0;
            var result = db.Appoinment.Where(r => r.userid == id).ToList();
            return View(result);
        }
    }
}