using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Services;
using Mooshark2.Models.DAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace Mooshark2.Controllers
{
    public class TeacherController : Controller
    {
        private ApplicationDbContext db;
        private CourseService courseService = new CourseService();
        private ProjectService projectService = new ProjectService();
        
        // GET: Teacher
        public ActionResult Index()
        {
            string userId =User.Identity.GetUserId();
            var ungradedProjects = projectService.getUngradedProjects(userId);
            var teacherCourses = courseService.getCoursesForTeacher(userId);
            
            return View();
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