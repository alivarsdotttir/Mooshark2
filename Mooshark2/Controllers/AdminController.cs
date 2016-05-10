﻿using System;
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
            var students = userService.GetAllStudentsUsers();

            //Course course = new Course(); 
            //var teachers = userService.GetAllTeachers();
            //var students = userService.GetAllStudents();

            //AdminCourseViewModel model = new AdminCourseViewModel(course, teachers, students);

            AdminCourseViewModel model = new AdminCourseViewModel(students);

            return View(model); 
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
                var students = userService.GetAllStudentsUsers();

                AdminCourseViewModel m = new AdminCourseViewModel(students);

                return View(m);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {

                        if (id.HasValue)
            {
                int realID = id.Value;
                
                Course course = (from item in db.Courses
                   where item.ID == id.Value
                    select item).SingleOrDefault();
                
                                if (course == null)
                {
                                        return View("NotFound");
                                    }
                
                                //ViewBag.Teachers = userService.GetAllTeachersInCourse(course.ID);
                                //ViewBag.Students = userService.GetAllStudentsInCourse(course.ID);
                ViewBag.TeachersNotInCourse = userService.GetAllTeachersNotInCourse(course.ID);
                ViewBag.StudentsNotInCourse = userService.GetAllStudentsNotInCourse(course.ID);
                var teachers = userService.GetAllTeachersInCourse(course.ID);
                var students = userService.GetAllStudentsInCourse(course.ID);
                
                AdminCourseViewModel model = new AdminCourseViewModel(course, teachers, students);
                
                                return View(model);
                            }
                        else
             {
                                return View("NotFound");
                            }
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {

            if (course != null)
            {
                Course model = (from item in db.Courses
                                 where item.ID == course.ID
                                 select item).SingleOrDefault();

                model.Name = course.Name;
                model.Active = course.Active;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }

        public ActionResult StudentEditList()
        {
            var allStudents = userService.GetAllStudents();

            return View(allStudents);
        }


        [HttpGet]
        public ActionResult EditStudent(string id)
        {
            if (id != null)
            {

                ApplicationUser student = (from item in db.Users
                                 where item.Id == id
                                 select item).SingleOrDefault();

                if (student == null)
                {
                    return View("NotFound");
                }

                return View(student);
            }
            else
            {
                return View("NotFound");
            }
        }

        [HttpPost]
        public ActionResult EditStudent(ApplicationUser student)
        {
            if (student != null)
            {
                ApplicationUser model = (from item in db.Users
                                where item.Id == student.Id
                                select item).SingleOrDefault();

             //   model. = course.Name;
            //    model.Active = course.Active;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("NotFound");
            }
        }

    }
}