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

            return View("NotFound");
        }


        public ActionResult ProjectDetails(int? id)
        {
            if(id != null)
            {
                var project = projectService.getProjectById(id.Value);
                var subprojects = projectService.getSubprojects(id.Value);
                var courseID = project.CourseID;
                var course = courseService.getCourseById(courseID.Value);

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

            return View("NotFound");
        }


        public ActionResult Submit(int? id)
        {
            if(id != null)
            {
                var subproject = projectService.getSubprojectById(id.Value);
                return View(subproject); 
            }

            return View("NotFound");
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
            var courseId = project.CourseID;
            var course = courseService.getCourseById(courseId.Value);

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
                //submission.Accepted = false;
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
                compiler.StandardInput.WriteLine("cl.exe /nologo /EHsc " + file.FileName);
                compiler.StandardInput.WriteLine("exit");
                string output = compiler.StandardOutput.ReadToEnd();
                compiler.WaitForExit(10000);
                compiler.Close();

                if (System.IO.File.Exists(exeFilePath))
                {
                    var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                    processInfoExe.UseShellExecute = false;
                    processInfoExe.RedirectStandardInput = true;
                    processInfoExe.RedirectStandardOutput = true;
                    processInfoExe.RedirectStandardError = true;
                    processInfoExe.CreateNoWindow = true;
                    processInfoExe.ErrorDialog = false;
                    using (var processExe = new Process())
                    {
                        processExe.StartInfo = processInfoExe;
                        processExe.Start();
                        
                        //Test input against code
                        StreamWriter inputWriter = processExe.StandardInput;
                        inputWriter.WriteLine(subproject.Input.ToString());

                        // We then read the output of the program:
                        StreamReader outputReader = processExe.StandardOutput;
                        string programOutput = outputReader.ReadToEnd().ToString();
                        string correctOutput = subproject.Output.ToString();
                        /*var programOutput = new List<string>();
                        while (!processExe.StandardOutput.EndOfStream)
                        {
                            programOutput.Add(processExe.StandardOutput.ReadLine());
                        }*/

                        //Create ViewModel, to be sent to SubmissionDetails view
                        submission.Output = programOutput;

                        if(string.Compare(programOutput, correctOutput) == 0) {
                            submission.Accepted = true;
                            submission.Grade = 10;
                        }
                        projectService.saveSubmissionChanges(submission.ID);
                        // StudentSubmissionDetailsViewModel model = new StudentSubmissionDetailsViewModel(course, project, subproject, submission, io);
                        return RedirectToAction("SubmissionDetails", new { submissionID = submission.ID });
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SubmissionDetails(int? submissionID)
        {
            if(submissionID != null) {
                Submission submission = projectService.getSubmissionById(submissionID.Value);
                int subprojectID = submission.SubprojectID;
                Subproject subproject = projectService.getSubprojectById(subprojectID);
                InputOutput inputOutput = projectService.getIOBySubprojectId(subprojectID);
                int projectID = subproject.ProjectID.Value;
                Project project = projectService.getProjectById(projectID);
                int courseID = project.CourseID.Value;
                Course course = courseService.getCourseById(courseID);

                StudentSubmissionDetailsViewModel model = new StudentSubmissionDetailsViewModel(course,
                    project,
                    subproject,
                    submission);

                return View(model);
            }

            return View("NotFound");
        }
    }
}