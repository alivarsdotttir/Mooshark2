using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mooshark2.Models.DAL;
using Mooshark2.Services;
using Microsoft.AspNet.Identity;
using Mooshark2.Models.ViewModels;
using Mooshark2.Models.Entities;
using Mooshark2.Models.ViewModels.StudentViewModels;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Mooshark2.Controllers
{
    public class StudentController : BaseController
    {
        
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var studentCourses = courseService.getCoursesForStudent(userId);
            var upcomingProjects = projectService.getUpcomingProjects(studentCourses);
            var coursesForProjects = courseService.getCoursesForMultipleProjects(upcomingProjects); 

            StudentIndexViewModel model = new StudentIndexViewModel(upcomingProjects, coursesForProjects, studentCourses); 
             
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
                var courseID = 1; //LAGA ÞETTA ÞVÍ TENGITAFLA VAR SETT INN
                var course = courseService.getCourseById(courseID);

                IEnumerable<Submission> submissions = null; 
                foreach(Subproject sub in subprojects)
                {
                    if (submissions == null)
                    {
                        submissions = projectService.getSubmissions(sub.ID);
                    }
                    else {
                        submissions = submissions.Concat(projectService.getSubmissions(sub.ID));
                    }
                }

               StudentDetailsViewModel model = new StudentDetailsViewModel(project, subprojects, submissions, course);
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

        [HttpPost]

        public ActionResult Submit(Subproject subproject, HttpPostedFileBase file)
        {   
             //get user who is logged in
             string userId = User.Identity.GetUserId();
             var user = userService.getUserById(userId);

            //get subproject, project and course
            int projectId = subproject.ProjectID ?? default(int);
            var project = projectService.getProjectById(projectId);
            var courseId = 1; //LAGA ÞETTA LÍKA KIDZZZZZ OG ÞÁ SÉRSTAKLEGA ÞÚ UNNUR
            var course = courseService.getCourseById(courseId);

            if (file.ContentLength > 0)
            {

                int submissionNumber = 1;
                var mostRecentSubmission = projectService.getMostRecentSubmission(user);
                if (mostRecentSubmission != null)
                {
                    submissionNumber = mostRecentSubmission.SubmissionNr + 1;
                }

                var fileName = Path.GetFileName(file.FileName);
                var filePath = string.Format("~\\Submissions\\{0}\\{1}\\{2}\\{3}\\{4}", course.Name, project.Name, subproject.Name, user.UserName, "Submission" + submissionNumber);
                

                var path = Path.Combine(Server.MapPath(filePath), fileName);
                
                System.IO.Directory.CreateDirectory(Server.MapPath(filePath));
                
                file.SaveAs(path);

                Submission submission = new Submission();
                submission.Date = DateTime.Now;
                submission.Accepted = true;  //Needs to change when test cases are implemented
                submission.SubprojectID = subproject.ID;
                submission.SubmissionNr = submissionNumber;
                submission.FilePath = Server.MapPath(filePath);
                submission.CppFileName = fileName; 

                projectService.createSubmission(submission, user);

                
                string exeFilePath = Server.MapPath(filePath) + "\\" + fileName.Remove(fileName.IndexOf(".")) + ".exe";
                //C++ compiler folder path
                var compilerFolder = "C:\\Program Files (x86)\\Microsoft Visual Studio 14.0\\VC\\bin\\";

                //Executing the compiler:
                Process compiler = new Process();
                compiler.StartInfo.FileName = "cmd.exe";
                compiler.StartInfo.WorkingDirectory = Server.MapPath(filePath);
                compiler.StartInfo.RedirectStandardInput = true;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.UseShellExecute = false;

                compiler.Start();
                compiler.StandardInput.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
                Debug.WriteLine("\"" + compilerFolder + "vcvars32.bat" + "\"");
                compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + file.FileName);
                Debug.WriteLine("cl.exe /nologo /EHsc " + file.FileName);
                compiler.StandardInput.WriteLine("exit");
                string output = compiler.StandardOutput.ReadToEnd();
                Debug.WriteLine(output);
                compiler.WaitForExit();
                compiler.Close();

                if (System.IO.File.Exists(exeFilePath))
                {
                    var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                    processInfoExe.UseShellExecute = false;
                    processInfoExe.RedirectStandardOutput = true;
                    processInfoExe.RedirectStandardError = true;
                    processInfoExe.CreateNoWindow = true;
                    using (var processExe = new Process())
                    {
                        processExe.StartInfo = processInfoExe;
                        processExe.Start();

                        // processExe.StandardInput.WriteLine()
                        //should be used for input 

                        // We then read the output of the program:
                        var lines = new List<string>();
                        while (!processExe.StandardOutput.EndOfStream)
                        {
                            lines.Add(processExe.StandardOutput.ReadLine());
                        }

                        ViewBag.Output = lines;
                    }

                }
            }

            return RedirectToAction("Index");
        }

        /*[HttpPost]
        public ActionResult Submit(HttpPostedFileBase file)
        {
            string userId = User.Identity.GetUserId();
            var user = userService.getUserById(userId);
            

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }*/


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