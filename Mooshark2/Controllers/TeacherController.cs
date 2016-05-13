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
            var coursesForProjects = courseService.getCoursesForMultipleProjects(ungradedProjects);
            var teacherCourses = courseService.getCoursesForTeacher(userId);

            TeacherIndexViewmodel model = new TeacherIndexViewmodel(ungradedProjects, coursesForProjects, teacherCourses);
            return View(model);
        }

        public ActionResult Course(int? id)
        {

            if(id != null)
            {
                var course = courseService.getCourseById(id.Value); 
                var courseProjects = projectService.getProjectsFromCourse(id.Value);

                TeacherCourseViewModel model = new TeacherCourseViewModel(course, courseProjects);
                 return View(model);
            }
            else 
                return View("NotFound");
           
        }

   
        //GET
        [HttpGet]
        public ActionResult CreateProject(int? id)
        {
            if(id.HasValue) {
                ViewBag.Course = id;

                return View();
            }
            else {
                return View("NotFound");
            }

        }


        //POST
        [HttpPost]
        public ActionResult CreateProject(Project model)
        {
            bool project = projectService.ServiceCreateProject(model);

            if (model.Name == null || model.Deadline == DateTime.MinValue || model.GroupSize == 0) {
                ModelState.AddModelError("", "You fill in all the input fields");
                ViewBag.Course = model.CourseID;

                return View();
            }

            if (project) {
                return RedirectToAction("CreateSubproject", new {id = model.ID});
            }
            else {

                ViewBag.Course = model.CourseID;

                return View();
            }
        }

        //GET
        [HttpGet]
        public ActionResult CreateSubproject(int? id)
        {
            if(id.HasValue) {
                ViewBag.Project = id;

                return View();
            }
            else {
                return View("NotFound");
            }
        }

        //POST
        [HttpPost]
        public ActionResult CreateSubproject(Subproject model)
        {
            bool subproject = projectService.ServiceCreateSubproject(model);
            if(model.Name == null || model.Description == null || model.Input == null || model.Output == null) {
                ModelState.AddModelError("", "You must fill in all the input fields");
                ViewBag.Course = model.ProjectID;

                return View();
            }

            if (subproject) {
                return RedirectToAction("ProjectDetails", new { id = model.ProjectID });
            }
            
            else {
                ViewBag.Course = model.ProjectID;

                return View();
            }
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

        //GET
        [HttpGet]
        public ActionResult EditSubproject(int? id)
        {
            Subproject project = db.Subprojects.Find(id.Value);
            return View(project);
        }


        //POST
        [HttpPost]
        public ActionResult EditSubproject(Subproject subproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subproject).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subproject);
        }

        public ActionResult ProjectDetails(int? id)
        {
            if(id != null)
            {
                var project = projectService.getProjectById(id.Value);
                var subprojects = projectService.getSubprojects(id.Value);

                TeacherProjectDetailsViewmodel model = new TeacherProjectDetailsViewmodel(project, subprojects);
                return View(model);
            }
            //Returns an error message, ID invalid 
            return View("NotFound");
        }


        [HttpGet]
        public ActionResult Submissions(int? subprojectId)
        {
            if(subprojectId != null) {

                var studentsThatHaveSubmitted = projectService.getStudentsThatHaveSubmitted(subprojectId.Value);

                var bestSubmissions = projectService.getStudentsBestSubmission(subprojectId.Value);
                var allSubmissionsForSubproject = projectService.getSubmissions(subprojectId.Value);
                var subprojectName = projectService.getSubprojectById(subprojectId.Value);

                TeacherSubmissionsViewmodel model = new TeacherSubmissionsViewmodel(allSubmissionsForSubproject,
                    studentsThatHaveSubmitted, bestSubmissions, subprojectName);

                return View(model);
            }

            return View("NotFound");
        }


        public ActionResult SubmissionDetails(int? id)
        {
            if (id != null) {
                var submission = projectService.getSubmissionById(id.Value);
                return View(submission);
            }

            return View();
        }


        [HttpGet]
        public ActionResult Graded(string UserId)
        {
            if(UserId != null) {
                ApplicationUser currentStudent = userService.getUserById(UserId);
                var submissions = projectService.getStudentsSubmissionsForSubproject(UserId); // OMG

                //TeacherGradeStudentViewModel model = new TeacherGradeStudentViewModel();
            }

            return View();
        }
    }
}