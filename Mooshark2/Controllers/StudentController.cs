using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.DAL;
using Mooshark2.Services;
using Microsoft.AspNet.Identity;
using Mooshark2.Services;
using Mooshark2.Models.ViewModels;
using Mooshark2.Models.Entities;

namespace Mooshark2.Controllers
{
    public class StudentController : Controller
    {
        private CourseService courseService = new CourseService();
        private ProjectService projectService = new ProjectService();
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var studentCourses = courseService.getCoursesForStudent(userId);
            var upcomingProjects = projectService.getUpcomingProjects(studentCourses);

            StudentIndexViewModel model = new StudentIndexViewModel(upcomingProjects, studentCourses); 
             
            return View(model);
        }


        public ActionResult Course(int? id)
        {
            if(id != null)
            {
                var course = courseService.getCourseById(id.Value); 
                var projects = projectService.getProjectsForCourse(id.Value);
                var teachers = courseService.getTeachersForCourse(id.Value);

                StudentCourseViewModel model = new StudentCourseViewModel(course, projects, teachers);

                return View(model); 
            }
            //Returns an error message, ID invalid 
            return View();
        }


        public ActionResult Details(int? id)
        {
            if(id != null)
            {
                var project = projectService.getProjectById(id.Value);
                var subprojects = projectService.getSubprojects(id.Value);

                IEnumerable<Submission> submissions = null; 
                foreach(Subproject sub in subprojects)
                {
                    submissions = submissions.Concat(projectService.getSubmissions(sub.ID)); 
                }

                StudentDetailsViewModel model = new StudentDetailsViewModel(project, subprojects, submissions);
                return View(model); 
            }
            //returns an error message, ID invalid, no project chosen
            return View();
        }


        public ActionResult Submit(int? id)
        {
            if(id != null)
            {
                var subproject = projectService.getSubprojectById(id.Value);
                return View(subproject); 
            }
            //error message, no subproject chosen, ID is invalid
            return View();
        }


        public ActionResult SubmisssionDetails(int? id)
        {
            if(id != null)
            {
                var submission = projectService.getSubmissionById(id.Value);
                return View(submission); 
            }
            return View();
        }
    }
}