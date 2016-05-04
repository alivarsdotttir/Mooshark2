using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.ViewModels;
using Mooshark2.Service;

namespace Mooshark2.Controllers
{
    public class AdminController : Controller
    {
        private CourseService courseService = new CourseService(); 
        public ActionResult Index()
        {
            var viewModel = courseService.getAllCourses();

            return View(viewModel);
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