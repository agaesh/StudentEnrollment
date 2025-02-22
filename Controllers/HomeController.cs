using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);  // Ensure you return LoginViewModel
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Submit your enquiry form.";

            return View();
        }
    }
}