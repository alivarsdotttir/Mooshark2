using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Services;
using Mooshark2.Models.DAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Mooshark2.Models.ViewModels.TeacherViewModels;

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
            string userId = User.Identity.GetUserId();
            var ungradedProjects = projectService.getUngradedProjects(userId);
            var teacherCourses = courseService.getCoursesForTeacher(userId);

            TeacherIndexViewmodel model = new TeacherIndexViewmodel(ungradedProjects, teacherCourses);
            return View(model);
        }

        public ActionResult Course(int? id)
        {
            if(id != null)
            {
                var course = courseService.getCourseById(id.Value); 
                var courseProjects = projectService.getProjectsFromCourse(id.Value);

                TeacherCourseVieweModel model = new TeacherCourseVieweModel(course, courseProjects);
                 return View(model);
            }
            //Returns an error message, ID invalid 
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

        public ActionResult ProjectDetails(int? id)
        {
            if(id != null)
            {

                return View();
            }
            //Returns an error message, ID invalid 
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