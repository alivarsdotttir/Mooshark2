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
    /// <summary>
    ///  The AdminController handels all comunications between the admin and the program.
    ///  It provides the admin with input by making tha right views shown on the right place on the screen.
    ///  It recives admin output and translates it in to the appropriate message to pass to the views needed.
    ///  It inherits from BaseController.cs
    /// </summary>

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
            var students = userService.GetAllStudentsUsers();

            AdminCourseViewModel model = new AdminCourseViewModel(students);

            return View(model); 
        }


        [HttpPost]
        public ActionResult CreateCourse(AdminCourseViewModel model)
        {
            bool course = courseService.ServiceCreateCourse(model);
            if(model.Teacher == null || model.Course == null) {
                ModelState.AddModelError("", "You must fill in all the input fields");

                ViewBag.Teachers = userService.GetAllTeachers();

                return View();
            }
            if (course) {

                return RedirectToAction("Index");
            }
            else {
                ViewBag.Teachers = userService.GetAllTeachers();
                var students = userService.GetAllStudentsUsers();

                AdminCourseViewModel m = new AdminCourseViewModel(students);

                return View(m);
            }
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue) {
                Course course = (from item in db.Courses
                                    where item.ID == id.Value
                                    select item).SingleOrDefault();
                
                if (course == null) {
                    return View("NotFound");
                }
                
                ViewBag.TeachersNotInCourse = userService.GetAllTeachersNotInCourse(course.ID);
                var studentsNotInCourse = userService.GetAllStudentsNotInCourse(course.ID);
                var teachers = userService.GetAllTeachersInCourse(course.ID);
                var students = userService.GetAllStudentsInCourse(course.ID);

                AdminCourseViewModel model = new AdminCourseViewModel(course, teachers, students, studentsNotInCourse);
                
                return View(model);
            }
            else {
                return View("NotFound");
            }
        }


        [HttpPost]
        public ActionResult Edit(AdminCourseViewModel model)
        {
            if (model.Course != null) {
                courseService.ServiceEditCourse(model);

                ViewBag.TeachersNotInCourse = userService.GetAllTeachersNotInCourse(model.Course.ID);
                var studentsNotInCourse = userService.GetAllStudentsNotInCourse(model.Course.ID);
                var teachers = userService.GetAllTeachersInCourse(model.Course.ID);
                var students = userService.GetAllStudentsInCourse(model.Course.ID);

                AdminCourseViewModel newModel = new AdminCourseViewModel(model.Course, teachers, students, studentsNotInCourse);

                return View(newModel);
            }
            else {
                return View("NotFound");
            }
        }


        [HttpGet]
        public ActionResult RemoveTeacherFromCourse(string userId, int courseId)
        {
            if(userId != null) {
                courseService.RemoveTeacherFromCourse(userId, courseId);
            }
            
            return RedirectToAction("Edit", new { id = courseId });
        }


        [HttpGet]
        public ActionResult RemoveStudentFromCourse(string userId, int courseId)
        {
            if(userId != null) {
                courseService.RemoveStudentFromCourse(userId, courseId);
            }

            return RedirectToAction("Edit", new { id = courseId });
        }


        public ActionResult UserEditList()
        {
            var allUsers = userService.GetAllUsers();

            return View(allUsers);
        }


        [HttpGet]
        public ActionResult EditUser(string id)
        {
            ApplicationUser user = db.Users.Find(id);
            return View(user);
        }


        [HttpPost]
        public ActionResult EditUser(ApplicationUser user)
        {
            if(ModelState.IsValid) {
                ApplicationUser u = userService.ServiceEditUser(user);
                return RedirectToAction("UserEditList");
            }

            return View(user);
        }
    }
}