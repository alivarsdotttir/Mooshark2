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
using Mooshark2.Models.Entities;

namespace Mooshark2.Controllers
{
    public class TeacherController : BaseController
    {

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


        //GET
        [HttpGet]
        public ActionResult CreateProject()
        {
            var project = new Project();
            return View(project);
        }


        //POST
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            if (projectService.ServiceCreatProject(project)) {
                return RedirectToAction("Index");
            }
            else {
                return View(project);
            }

            return View();
        }

        //GET
        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            Project project = db.Projects.Find(id.Value);
            return View(project);
        }

        //POST
        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            if(ModelState.IsValid)
            {
                db.Entry(project).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(project);
        }

        public ActionResult ProjectDetails(int? id)
        {
            if(id != null)
            {
                var project = projectService.getProjectById(id.Value);
                var subprojects = projectService.getSubprojects(id.Value);

                TeacherDetailsViewmodel model = new TeacherDetailsViewmodel(project, subprojects);
                return View(model);
            }
            //Returns an error message, ID invalid 
            return View();
        }

        public ActionResult Submissions()
        {
            string userId = User.Identity.GetUserId();
            var students = projectService.getSubmitedStudents(userId);
            var mostRecentSubmission = projectService.getStudentsBestSubmission(userId);

            TeacherSubmitsViewmodels model = new TeacherSubmitsViewmodels(mostRecentSubmission, students);

            return View(model);
        }

        public ActionResult SubmissionDetails(int? id)
        {
            if (id != null)
            {
                var submission = projectService.getSubmissionById(id.Value);
                return View(submission);
            }
            return View();
        }
    }

}