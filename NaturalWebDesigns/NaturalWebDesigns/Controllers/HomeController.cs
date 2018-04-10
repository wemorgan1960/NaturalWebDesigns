using Microsoft.AspNet.Identity;
using NaturalWebDesigns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NaturalWebDesigns.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Our Services";

            return View();
        }

        public ActionResult Portofolio()
        {
            ViewBag.Message = "Our Portofolio.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.IsIndexHome = false;
            ViewBag.Message = "NaturalWebDesigns.com contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactAsync(EmailFormModel model)
        {
            ViewBag.IsIndexHome = false;
            if (ModelState.IsValid)
            {
                //Email Customer
                var email = new EmailService();
                var message = new IdentityMessage();

                message.Destination = "admin@naturalwebdesigns.com";

                var bodyBuilder = new StringBuilder();
                bodyBuilder.AppendLine("Email From: admin@naturalwebdesigns.com");
                bodyBuilder.AppendLine("");
                bodyBuilder.AppendLine("Name: " + model.FromName);
                bodyBuilder.AppendLine("");
                bodyBuilder.AppendLine("Email address" + model.FromEmail);
                bodyBuilder.AppendLine("");
                bodyBuilder.AppendLine("Message: " + model.Message);

                message.Body = bodyBuilder.ToString();

                email.SendAsync(message);

                return RedirectToAction("Sent");
            }
            else
            {
                return View();
            }
        }
    }
}