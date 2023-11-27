using AspNetCoreHero.ToastNotification.Abstractions;
using HealthHub_Records.Models;
using HealthHub_Records.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthHub_Records.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotyfService _notyf;
        private readonly HealthhubDbContext db;
     
        public HomeController(ILogger<HomeController> logger, HealthhubDbContext db, INotyfService notyf)
        {
            _logger = logger;
            this.db = db;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
           var result=db.Contacts.Add(contact);
           db.SaveChanges();
            _notyf.Success("Messaage Sent");
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            var result = db.Users.FirstOrDefault(r => r.username == username && r.password == password && r.isactive == true);

            if (result != null && result.RoleId == 2)
            {
                ISession session = HttpContext.Session; // Get the session object
                int userId = result.userid; // Assuming "result" has a property named "userid"

                // Store the "userid" in the session
                session.SetInt32("UserId", userId);
                
                return RedirectToAction("PatientDashboard", "Patient");
            }

            else if (result != null && result.RoleId == 3)
            {
                ISession session = HttpContext.Session; 
                int userId = result.userid; 

                session.SetInt32("UserId", userId);
                return RedirectToAction("HospitalDashboard", "Hospital");

            }
            else if (result != null && result.RoleId == 1)
            {
                ISession session = HttpContext.Session; 
                int userId = result.userid; 

                
                session.SetInt32("UserId", userId);
                return RedirectToAction("AdminDashboard", "Admin");
            }
            else {

                _notyf.Error("Incorrect Credentials Try again!");
                return RedirectToAction("Login");
            }

        }

        public IActionResult Logout()
        {
            ISession session = HttpContext.Session; 
            session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var result = db.Users.FirstOrDefault(r => r.userid == userId );
            if (result != null)
            {
                ViewBag.Role = result.RoleId;
            }
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
                _notyf.Success("Password Changed Successfully Need to Login Again!");
                return RedirectToAction("Logout");


            }
            else
            {
              
                return View();

            }

        }

        
        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}