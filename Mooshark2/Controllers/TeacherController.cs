using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Service;
using Mooshark2.Models.DAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Mooshark2.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationDbContext db;
        private CourseService courseService = new CourseService();
        
        // GET: Teacher
        public ActionResult Index()
        {
            var userId =User.Identity.GetUserId();
            var viewModel = courseService.getCoursesForTeacher(userId);
            return View(viewModel);
        }

        public ActionResult Course()
        {
            return View();
        }

        public ActionResult CreateProject()
        {
            return View();
        }

        public ActionResult EditProject()
        {
            return View();
        }

        public ActionResult ProjectDetails()
        {
            return View();
        }

        public ActionResult Submissions()
        {
            return View();
        }

        public ActionResult SubmissionDetails()
        {
            return View();
        }
    }

}