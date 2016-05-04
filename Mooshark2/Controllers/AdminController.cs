using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.DAL;
using Mooshark2.Models.ViewModels;
using Mooshark2.Service;

namespace Mooshark2.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db; 
        private CourseService courseService = new CourseService(); 
        public ActionResult Index()
        {
            var viewModel = courseService.getAllCourses();

            return View(viewModel);
        }

        public ActionResult CreateCourse()
        {
            return View(); 
        }

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