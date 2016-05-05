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
    public class AdminController : BaseController
    {

        public ActionResult Index()
        {
            var viewModel = courseService.GetAllCourses();

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
            if (ModelState.IsValid)
            {
                //ApplicationUser newUser = new ApplicationUser();

                /*newUser.Email = model.Email;
                newUser.UserName = model.UserName;
                newUser.PasswordHash = model.PasswordHash;*/

                db.Users.Add(model);
                var success = db.SaveChanges();

                /*if (success == fail)
                {
                    //villa, fail 0 or 1
                }*/
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}