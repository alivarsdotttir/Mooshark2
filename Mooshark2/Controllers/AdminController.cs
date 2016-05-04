using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mooshark2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult createCourse()
        {
            return View(); 
        }

        public ActionResult createUser()
        {
            return View(); 
        }

        public ActionResult edit()
        {
            return View(); 
        }
    }
}