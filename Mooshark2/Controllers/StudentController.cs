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
    /// <summary>
    ///  The StudentController handels all comunications between the student and the program.
    ///  It provides the student with input by making tha right views shown in the right place on the screen.
    ///  It recives the student output and translates it in to the appropriate message to pass to the views needed.
    ///  It inherits from BaseController.cs
    /// </summary>

    [Authorize(Roles = "Student")]
    public class StudentController : BaseController
    {
        //Returns the Index view 
        [HttpGet]
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var studentCourses = courseService.getCoursesForStudent(userId);
            var upcomingProjects = projectService.getUpcomingProjects(studentCourses);
            var coursesForProjects = courseService.getCoursesForMultipleProjects(upcomingProjects); 

            StudentIndexViewModel model = new StudentIndexViewModel(upcomingProjects, coursesForProjects, studentCourses); 
             
            return View(model);
        }


        //Returns the Course view, a view for a course with the ID specified
        [HttpGet]
        public ActionResult Course(int? id)
        {
            if(id != null) {

                var course = courseService.getCourseById(id.Value); 
                var projects = projectService.getProjectsForCourse(id.Value);
                var teachers = courseService.getTeachersForCourse(id.Value);

                StudentCourseViewModel model = new StudentCourseViewModel(course, projects, teachers);

                return View(model); 
            }

            return View("NotFound");
        }

        
        //Returns the ProjectDetails view, a view where the details of a project and its subprojects are displayed
        [HttpGet]
        public ActionResult ProjectDetails(int? id)
        {
            if(id != null) {
                var project = projectService.getProjectById(id.Value);
                var userId = User.Identity.GetUserId();
                var subprojects = projectService.getSubprojects(id.Value);
                var courseID = project.CourseID;
                var course = courseService.getCourseById(courseID.Value);

                List<Submission> submissions = null; 
                foreach(Subproject sub in subprojects) {
                    if (submissions == null) {
                        submissions = projectService.getSubmissionsForStudents(sub.ID, userId);
                    }
                    else {
                        submissions.AddRange(projectService.getSubmissionsForStudents(sub.ID, userId));
                    }
                }

               StudentDetailsViewModel model = new StudentDetailsViewModel(project, subprojects, submissions, course);
               return View(model); 
            }

            return View("NotFound");
        }

        
        //Returns the Submit view, a view where the students can submit their solutions
        [HttpGet]
        public ActionResult Submit(int? id)
        {
            if(id != null)
            {
                var subproject = projectService.getSubprojectById(id.Value);
                var projectId = subproject.ProjectID;
                var project = projectService.getProjectById(projectId.Value);
                ViewBag.Students = userService.GetAllStudentsInCourseSelectList(project.CourseID.Value);
                List<ApplicationUser> students = userService.GetAllStudentsInCourse(project.CourseID.Value);

                StudentSubmitViewModel model = new StudentSubmitViewModel(project, subproject, students);

                return View(model); 
            }

            return View("NotFound");
        }

        
        //A function that compiles the code posted by the user
        [HttpPost]
        public ActionResult Submit(Subproject subproject, HttpPostedFileBase file)
        {   
            try { 
            //get user who is logged in
             string userId = User.Identity.GetUserId();
             var user = userService.getUserById(userId);

            //get subproject, project and course
            int projectId = subproject.ProjectID ?? default(int);
            var project = projectService.getProjectById(projectId);
            var courseId = project.CourseID;
            var course = courseService.getCourseById(courseId.Value);
            List<ApplicationUser> students = userService.GetAllStudentsInCourse(project.CourseID.Value);
            ViewBag.Students = userService.GetAllStudentsInCourseSelectList(project.CourseID.Value);

            //View Model for error check
            StudentSubmitViewModel model = new StudentSubmitViewModel(project, subproject, students);
            
            //Error check, empty submission
            if(file == null) {
                ModelState.AddModelError("", "Empty submission, please choose a file.");
                return View(model); 
            }

            //Error check, wrong file extension
            var fileName = Path.GetFileName(file.FileName);
            if(fileName.Substring(fileName.Length-4, 4) != ".cpp") {
                ModelState.AddModelError("", "Wrong file extension, file must be of type cpp.");
                return View(model);
            }

            //Checks if there is anything inside the file
            if (file.ContentLength > 0) {
                int submissionNumber = 1;
                var mostRecentSubmission = projectService.getMostRecentSubmission(user, subproject.ID);
                if (mostRecentSubmission != null) {
                    submissionNumber = mostRecentSubmission.SubmissionNr + 1;
                }
                
                //Creates the name of the file path
                var filePath = string.Format("~\\Submissions\\{0}\\{1}\\{2}\\{3}\\{4}", course.Name, project.Name, subproject.Name, user.UserName, "Submission" + submissionNumber);

                //Creates the name of the the path where the submission will be stored, so filePath + name of file submitted
                var path = Path.Combine(Server.MapPath(filePath), fileName);
                
                //Creates the file path
                System.IO.Directory.CreateDirectory(Server.MapPath(filePath));
                
                //Creates the file itself
                file.SaveAs(path);
                
                //Create the submission in the database
                Submission submission = new Submission();
                submission.Date = DateTime.Now;
                submission.SubprojectID = subproject.ID;
                submission.SubmissionNr = submissionNumber;
                submission.FilePath = Server.MapPath(filePath);
                submission.CppFileName = fileName;
                submission.StudentId = userId;
                
                projectService.createSubmission(submission, user);
                
                //Creates the name of the exe file path
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
                int compileTime = compiler.TotalProcessorTime.Milliseconds;
                compiler.Close();
                compiler.Dispose();

                if(compileTime == 10000) {
                    ModelState.AddModelError("", "Compile time error");
                    return View(model);
                }

                //If the exe file exists, run the code 
                if(System.IO.File.Exists(exeFilePath)) {
                    var processInfoExe = new ProcessStartInfo(exeFilePath, "");
                    processInfoExe.UseShellExecute = false;
                    processInfoExe.RedirectStandardInput = true;
                    processInfoExe.RedirectStandardOutput = true;
                    processInfoExe.RedirectStandardError = true;
                    processInfoExe.CreateNoWindow = true;
                    processInfoExe.ErrorDialog = false;
                    using(var processExe = new Process()) {
                        processExe.StartInfo = processInfoExe;
                        processExe.Start();
                        processExe.WaitForExit(300000);

                        //It there is input, test it against code
                        StreamWriter inputWriter = processExe.StandardInput;
                        if(subproject.Input != null) {
                            inputWriter.WriteLine(subproject.Input.ToString());
                        }
                        inputWriter.Dispose();

                        // We then read the output of the program for 30 seconds, or until end of the output:
                        StreamReader outputReader = processExe.StandardOutput;
                        
                        string programOutput = outputReader.ReadToEnd();
                        outputReader.Close();
                        outputReader.Dispose();
                        processExe.Dispose();

                        string correctOutput = subproject.Output.ToString();

                        //removing \n\r from the back of the input so that it's comparable
                        if(programOutput.Length > 2) {
                            string programOutputCorrected = programOutput.Remove(programOutput.Length - 2);

                            //Create ViewModel, to be sent to SubmissionDetails view
                            submission.Output = programOutput;
                            
                            //Updates the grade and accepted of a submission
                            if(string.Compare(programOutputCorrected, correctOutput) == 0) {
                                submission.Accepted = true;
                                submission.Grade = 10;
                            }
                            else {
                                submission.Accepted = false;
                                submission.Grade = 0;
                            }
                        }
                    }
                    projectService.saveSubmissionChanges(submission.ID);
                            
                    return RedirectToAction("SubmissionDetails", new { submissionID = submission.ID });
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("The process failed: {0}", e.ToString());
                return View();

            }

            return View();
        }


        //Returns the SubmissionDetails view for a certain submission
        [HttpGet]
        public ActionResult SubmissionDetails(int? submissionID)
        {
            if(submissionID != null) {
                Submission submission = projectService.getSubmissionById(submissionID.Value);
                int subprojectID = submission.SubprojectID;
                Subproject subproject = projectService.getSubprojectById(subprojectID);
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