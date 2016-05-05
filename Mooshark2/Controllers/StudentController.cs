using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.DAL;
using Mooshark2.Service;
using Microsoft.AspNet.Identity;

namespace Mooshark2.Controllers
{
    public class StudentController : Controller
    {
        private CourseService courseService = new CourseService();
        //private ProjectService 
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var studentCourses = courseService.getCoursesForStudent(userId);
            //var projectsToTurnIn = courseService.getUpcomingProjects(userId); 
            return View();
        }


        public ActionResult Course()
        {
            return View();
        }


        public ActionResult Details()
        {
            return View();
        }


        public ActionResult Submit()
        {
            return View();
        }


        public ActionResult SubmisssionDetails()
        {
            return View();
        }
    }
}