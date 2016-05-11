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
            //Returns an error message, ID invalid 
            return View();
           
        }

   
        //GET
        [HttpGet]
        public ActionResult CreateProject(int? id)
        {
            if(id != null) { 
                var project = new Project();
                var subproject = new Subproject();
                //IEnumerable<Subproject> subprojects = new List<Subproject>();
                var course = courseService.getCourseById(id.Value);

                TeacherCreateViewModel model = new TeacherCreateViewModel(project, subproject, course);
                return View(model);
            }

            return View();
            
        }


        //POST
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            /*if (projectService.ServiceCreateProject(project)) {
                return RedirectToAction("Index");
            }
            else {
                return View(project);
            }*/

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
                var currentCourse = courseService.getCourseById(id.Value);

                TeacherProjectDetailsViewmodel model = new TeacherProjectDetailsViewmodel(project, subprojects, currentCourse);
                return View(model);
            }
            //Returns an error message, ID invalid 
            return View();
        }

        [HttpGet]
        public ActionResult Submissions(int? subprojectID)
        {
            if(subprojectID != null) {
                var students = projectService.getStudentsThatHaveSubmitted(subprojectID.Value);
                List<Submission> bestSubmissions = new List<Submission>();
                foreach (var student in students) {
                    bestSubmissions.Add(projectService.getStudentsBestSubmission(student.Id));
                }
                var allSubmissionsForSubproject = projectService.getSubmissions(subprojectID.Value);
                var subprojectName = projectService.getSubprojectById(subprojectID.Value);

                TeacherSubmissionsViewmodel model = new TeacherSubmissionsViewmodel(allSubmissionsForSubproject,
                    students,
                    bestSubmissions, subprojectName);

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
        public ActionResult Graded(int? id)
        {
            if(id != null) {
                var currentStudentID = User.Identity.GetUserId();
                var currentStudent = userService.getUserById(currentStudentID);
                var currentProject = projectService.getProjectById(id.Value);
               // var studentSubmissions;

                TeacherGradeStudentViewModel model = new TeacherGradeStudentViewModel(currentStudent, currentProject);
                //TeacherGradeStudentViewModel model = new TeacherGradeStudentViewModel(currentStudent, currentProject);

                return View(model);
            }

            return View();
        }
    }
}