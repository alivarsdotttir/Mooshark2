﻿using System;
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
    /// <summary>
    ///  The TeacherController handles all communications between the teacher and the program.
    ///  It provides the teacher with input by making tha right views shown in the right place on the screen.
    ///  It recives the teacher output and translates it in to the appropriate message to pass to the views needed.
    ///  It inherits from BaseController.cs
    /// </summary>

    [Authorize(Roles = "Teacher")]
    public class TeacherController : BaseController
    {
        // Returns the index view for teachers
        [HttpGet]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var ungradedProjects = projectService.getUngradedProjects(userId);
            var coursesForProjects = courseService.getCoursesForMultipleProjects(ungradedProjects);
            var teacherCourses = courseService.getCoursesForTeacher(userId);

            TeacherIndexViewmodel model = new TeacherIndexViewmodel(ungradedProjects, coursesForProjects, teacherCourses);
            return View(model);
        }


        // Returns the view for a single course
        [HttpGet]
        public ActionResult Course(int? id)
        {
            if(id != null) {
                var course = courseService.getCourseById(id.Value); 
                var courseProjects = projectService.getProjectsFromCourse(id.Value);

                TeacherCourseViewModel model = new TeacherCourseViewModel(course, courseProjects);
                 return View(model);
            }
            else {
                return View("NotFound");
            }
        }

   
        // Returns the view for creating a project
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


        // The post method for creating a project
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


        // Returns the view for creating a subproject
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


        // The post method for creating a subproject
        [HttpPost]
        public ActionResult CreateSubproject(Subproject model)
        {
            if(model.Name == null || model.Description == null || model.Input == null || model.Output == null) {
                ModelState.AddModelError("", "You must fill in all the input fields");
                ViewBag.Course = model.ProjectID;

                return View();
            }

            bool subproject = projectService.ServiceCreateSubproject(model);

            if (subproject) {
                return RedirectToAction("ProjectDetails", new { id = model.ProjectID });
            }
            else {
                ViewBag.Course = model.ProjectID;

                return View();
            }
        }


        // Returns the view for editing a project
        [HttpGet]
        public ActionResult EditProject(int? id)
        {
            Project project = db.Projects.Find(id.Value);
            return View(project);
        }


        // The post method for editing a project
        [HttpPost]
        public ActionResult EditProject(Project project)
        {
            if(ModelState.IsValid) {
                Project proj = projectService.ServiceEditProject(project);
                return RedirectToAction("ProjectDetails", new { id = proj.ID});
            }

            return View(project);
        }


        // Returns the view for editing a subproject
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
            if (ModelState.IsValid) {
                Subproject sub = projectService.ServiceEditSubproject(subproject);
                return RedirectToAction("ProjectDetails", new { id = sub.ProjectID });
            }

            return View(subproject);
        }

        // The post method for editing a project
        public ActionResult ProjectDetails(int? id)
        {
            if(id != null) {
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
                var studentsForSubmissions = projectService.getStudentBySubmission(bestSubmissions);
                var allSubmissionsForSubproject = projectService.getSubmissions(subprojectId.Value);
                var subprojectName = projectService.getSubprojectById(subprojectId.Value);

                TeacherSubmissionsViewmodel model = new TeacherSubmissionsViewmodel(allSubmissionsForSubproject,
                    studentsThatHaveSubmitted, bestSubmissions, studentsForSubmissions, subprojectName);

                return View(model);
            }
            return View("NotFound");
        }


        public ActionResult StudentSubmissions(string studentId, int? subprojectId)
        {
            if (studentId != null && subprojectId != null) {
                var student = userService.getUserById(studentId); 
                var submissions = projectService.getStudentsSubmissionsForSubproject(studentId);
                var subproject = projectService.getSubprojectById(subprojectId.Value);

                TeacherStudentSubmissionsViewModel model = new TeacherStudentSubmissionsViewModel(student, subproject, submissions);
                return View(model);
            }

            return View("NotFound");
        }


        [HttpGet]
        public ActionResult SubmissionDetail(int? submissionId, string studentId)
        {
            if(submissionId != null && studentId != null) {
                var student = userService.getUserById(studentId);
                var submission = projectService.getSubmissionById(submissionId.Value);
                var subprojectId = submission.SubprojectID;
                var subproject = projectService.getSubprojectById(subprojectId);

                TeacherSubmissionsDetailViewModel model = new TeacherSubmissionsDetailViewModel(student, subproject, submission);

                return View(model); 
            }

            return View("NotFound");
        }


        [HttpPost]
        public ActionResult SubmissionDetail(TeacherSubmissionsDetailViewModel model)
        {
            projectService.updateGrade(model);

            return RedirectToAction("Submissions", new { subprojectId = model.currentSubproject.ID}); 
        }


        public ActionResult Grades(int? projectId)
        {
            if(projectId != null) {

            }
            return View("NotFound"); 
        }
    }
}