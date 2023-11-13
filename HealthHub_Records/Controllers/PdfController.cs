using HealthHub_Records.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.Drawing.Printing;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace HealthHub_Records.Controllers
{
    public class PdfController : Controller
    {
        private readonly HealthhubDbContext db;
        public PdfController(HealthhubDbContext db)
        {
            this.db = db;   
            
        }
      

        [HttpGet]
        public IActionResult GeneratePdf(string view)
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var user = db.PatientRegs.FirstOrDefault(r => r.userid == userId);
            if (user != null)
            {
                var document = new PdfDocument();
                string HtmlContent = " <div style='width:300px;background-color: #F0F8FF;border:2px solid #6495ED '>";
                HtmlContent += "<div style='text-align: center;background-color: #6495ED;padding-bottom:15px'>";
                HtmlContent += "<h2>Patient Card</h2>";
                HtmlContent += "</div>";
                HtmlContent += "<div >";
                HtmlContent += "<p>User Id:XXXXXXX" + user.userid + "</p>";
                HtmlContent += " <p>Name:"+user.firstname+" "+ user.lastname+"</p>";
                HtmlContent += "<p>Address:"+ user.address +"</p>";
                HtmlContent += "<p>State:"+user.state+"</p>";
                HtmlContent += "<p>City:" + user.city + "</p>";
                HtmlContent += "<p>Date of Birth:" + user.dob + "</p>";
                HtmlContent += "<p>Gender:" + user.gender + "</p>";
                HtmlContent += "</div>";
                HtmlContent += "</div>";
             

                PdfGenerator.AddPdfPages(document, HtmlContent, PageSize.A4);
                byte[]? reponse = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    document.Save(ms);
                    reponse = ms.ToArray();

                }
                if (string.Equals(view, "true", StringComparison.OrdinalIgnoreCase))
                {
                    // Show the PDF in the browser
                    return File(reponse, "application/pdf");
                }
                else
                {
                    // Download the PDF
                    var filename = "Abc" + ".pdf";
                    return File(reponse, "application/pdf", filename);
                }
            }
            else
            {

                return NotFound();


            }
        }


        public ActionResult Index()
        {
            return View("GeneratePdf");
        }


    }
}
