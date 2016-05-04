using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.DAL;
using Mooshark2.Service;


namespace Mooshark2.Controllers
{
    public class StudentController : Controller
    {
        //private ApplicationDbContext db;
        //private CourseService courseService = new CourseService();
        // GET: Student
        public ActionResult Index()
        {

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