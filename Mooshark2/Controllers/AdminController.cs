using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using Mooshark2.Models.ViewModels;
using Mooshark2.Models.ViewModels.AdminViewModels;
using Mooshark2.Services;

namespace Mooshark2.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController :  BaseController
    {
        public ActionResult Index()
        {
            var viewModel = courseService.GetAllCourses();

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult CreateCourse()
        {
            ViewBag.Teachers = userService.GetAllTeachers();
            ViewBag.Students = userService.GetAllStudents();
            //Course course = new Course(); 

            //AdminCourseViewModel model = new AdminCourseViewModel();

            return View(); 
        }


        [HttpPost]
        public ActionResult CreateCourse(AdminCourseViewModel model)
        {
            bool course = courseService.ServiceCreateCourse(model);

            if (course) {

                return RedirectToAction("Index");
            }
            else {
                ViewBag.Teachers = userService.GetAllTeachers();
                ViewBag.Students = userService.GetAllStudents();

                return View(model);
            }
        }


        public ActionResult Edit(Course model)
        {
            return View(model); 
        }
    }
}