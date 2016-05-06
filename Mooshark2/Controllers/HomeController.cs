using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshark2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("Index", "Student");
            }

            return View();
        }

    }
}