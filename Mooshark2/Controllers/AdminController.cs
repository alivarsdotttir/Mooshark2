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
using Mooshark2.Service;

namespace Mooshark2.Controllers
{
    public class RedirectToAction :  BaseController
    {
        //private ApplicationDbContext db; 
        private CourseService courseService = new CourseService(); 
        public ActionResult Index()
        {
            var viewModel = courseService.GetAllCourses();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult CreateCourse()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            if(courseService.ServiceCreateCourse(course)) {
                return RedirectToAction("Index");
            }
            else {
                return View(course);
            }
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            ApplicationUser model = new ApplicationUser();
            return View(model); 
        }

        [HttpPost]
        public ActionResult CreateUser(ApplicationUser model)
        {
            if(ModelState.IsValid) {
                ApplicationUser newUser = new ApplicationUser();

                newUser.Email = model.Email;
                newUser.UserName = model.UserName;
                newUser.PasswordHash = model.PasswordHash;

                newUser.EmailConfirmed = false;
                newUser.PhoneNumberConfirmed = false;
                newUser.TwoFactorEnabled = false;
                newUser.LockoutEnabled = true;
                newUser.AccessFailedCount = 0;

                db.Users.Add(newUser); 
                // Kastar null exception, veit ekki af hverju. Þarf aðstoð. 
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditUser()
        {
            return View(); 
        }
    }
}