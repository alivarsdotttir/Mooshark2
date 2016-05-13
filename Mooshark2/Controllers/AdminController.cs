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
        //Returns the Index view for admin
        //Where the admin can choose to create a course and  an user or edit them and sees a list of all the courses
        public ActionResult Index()
        {
            var viewModel = courseService.GetAllCourses();

            return View(viewModel);
        }


        //Returns the CreateCourse view for admin
        //Where the admin can create a course
        [HttpGet]
        public ActionResult CreateCourse()
        {
            ViewBag.Teachers = userService.GetAllTeachers();
            var students = userService.GetAllStudentsUsers();

            AdminCourseViewModel model = new AdminCourseViewModel(students);

            return View(model); 
        }


        //Updates the CreateCourse view for admin
        //Where the changes that the admin has made are sent back to the database
        [HttpPost]
        public ActionResult CreateCourse(AdminCourseViewModel model)
        {
            bool course = courseService.ServiceCreateCourse(model);

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


        //Returns the Edit view for admin
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

        //Updates the Edit view for admin
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


        //Returns the RemoveTeacherFromCourse view for admin
        [HttpGet]
        public ActionResult RemoveTeacherFromCourse(string userId, int courseId)
        {
            if(userId != null) {
                courseService.RemoveTeacherFromCourse(userId, courseId);
            }
            
            return RedirectToAction("Edit", new { id = courseId });
        }


        //Updates the RemoveStudentFromCourse view for admin
        [HttpGet]
        public ActionResult RemoveStudentFromCourse(string userId, int courseId)
        {
            if(userId != null) {
                courseService.RemoveStudentFromCourse(userId, courseId);
            }

            return RedirectToAction("Edit", new { id = courseId });
        }


        //Returns the UserEditList view for admin
        public ActionResult UserEditList()
        {
            var allUsers = userService.GetAllUsers();

            return View(allUsers);
        }


        //Returns the EditUser view for admin
        [HttpGet]
        public ActionResult EditUser(string id)
        {

            ApplicationUser user = db.Users.Find(id);
            return View(user);
        }


        //Updates the EditUser view for admin
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