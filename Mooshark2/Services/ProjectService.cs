using Mooshark2.Models;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;
using Microsoft.Ajax.Utilities;
using Mooshark2.Models.DAL;
using Mooshark2.Models.ViewModels.TeacherViewModels;

/// <summary>
/// This class is a connection to the database. It mainly concerns the projects, subprojects and submissions. 
/// </summary>

namespace Mooshark2.Services
{
    public class ProjectService
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ProjectService()
        {
            db = new ApplicationDbContext();
        }

        //Returns the projects for which the deadline has not passed
        public IEnumerable<Project> getUpcomingProjects(IEnumerable<Course> studentCourses)
        {
            IEnumerable<Project> upcomingProjects = null;

            foreach (Course course in studentCourses)
            {
                if (upcomingProjects == null)
                {
                    upcomingProjects = (from x in db.Projects
                                        where x.CourseID == course.ID && DateTime.Now < x.Deadline && x.Visibility == true
                                        select x) as IEnumerable<Project>;
                }
                else {
                    upcomingProjects = upcomingProjects.Concat(from x in db.Projects
                                                               where x.CourseID == course.ID && DateTime.Now < x.Deadline && x.Visibility == true
                                                               orderby x.Deadline ascending
                                                               select x) as IEnumerable<Project>;
                }

            }
            if (upcomingProjects != null)
            {
                return upcomingProjects;
            }
            return Enumerable.Empty<Project>();
        }

        //Creates a new project in the database
        public bool ServiceCreateProject(Project model)
        {
            if (db.Projects.Any(x => x.Name == model.Name))
            { 
                return false;
            }
            else {

                if(model.GroupSize > 1) {
                    model.IsGroupProject = true;
                }
                int CID = model.CourseID.Value;
                db.Projects.Add(model);
                db.CourseProjects.AddOrUpdate(new CourseProject { CourseID = CID, ProjectID = model.ID });
                db.SaveChanges();
                return true;
            }
        }

        //Returns all the projects for a certain course
        public IEnumerable<Project> getProjectsForCourse(int courseID)
        {
            IEnumerable<Project> projects = (from x in db.Projects
                                             where x.CourseID == courseID && x.Visibility == true 
                                             select x) as IEnumerable<Project>;
            if(projects != null) {
                return projects;
            }

            return Enumerable.Empty<Project>();
        }

        //Returns a certain project, which has the same ID as the one passed in as a parameter
        public Project getProjectById(int projectID)
        {
            Project project = (from x in db.Projects
                               where projectID == x.ID
                               select x).SingleOrDefault(); 
            return project; 
        }

        //Creates a subproject
        public bool ServiceCreateSubproject(Subproject model)
        {
            if (db.Subprojects.Any(x => x.Name == model.Name))
            {
                return false;
            }
            else
            {
                db.Subprojects.Add(model);
                db.SaveChanges();
                return true;
            }
        }

        //Returns all the subprojects linked to a project
       public List<Subproject> getSubprojects(int projectID)
        {
            List<Subproject> subprojects = (from x in db.Subprojects
                                                   where projectID == x.ProjectID
                                                   select x).ToList();

           return subprojects;
        }

        //Returns all the submissions for a subproject
        public List<Submission> getSubmissions(int subprojectID)
        {
            List<Submission> submissions = (from x in db.Submissions
                                                   where subprojectID == x.SubprojectID
                                                   select x).ToList();

                return submissions;
        }

        //Returns all the submissions for a certain user
        public List<Submission> getSubmissionsForStudents(int subprojectID, string userID)
        {
            List<Submission> submissions = (from x in db.Submissions
                                            where subprojectID == x.SubprojectID && x.StudentId == userID
                                            select x).ToList();

            return submissions;
        }

        //Returns a certain subrpoject, with the same ID as the one passed in as a parameter
        public Subproject getSubprojectById(int subprojectID)
        {
            Subproject subproject = (from x in db.Subprojects
                                     where subprojectID == x.ID
                                     select x).SingleOrDefault();

            return subproject;
        }

        //Returns a certain submission, with the same ID as the one passed in as a parameter
        public Submission getSubmissionById(int submissionID)
        {
            Submission submission = (from x in db.Submissions
                                     where submissionID == x.ID
                                     select x).SingleOrDefault();
            return submission;
        }

        //Returns all the projects that have not been graded by the teacher
        public IEnumerable<Project> getUngradedProjects(string teacherID)
        {
            IEnumerable<Project> ungradedProjects = (from x in db.Projects
                                                  join y in db.CourseTeachers on x.CourseID equals y.CourseID
                                                  where y.UserID == teacherID && x.Graded == false
                                                  select x) as IEnumerable<Project>;
            if(ungradedProjects != null) {
                return ungradedProjects;
            }

            return Enumerable.Empty<Project>();
        }

        //Returns all the projects linked to a course
        public IEnumerable<Project> getProjectsFromCourse(int courseID)
        {
            IEnumerable<Project> projectsFromCourse = (from x in db.Projects
                                                        where x.CourseID == courseID
                                                        select x) as IEnumerable<Project>;
            return projectsFromCourse;
        }

        //Returns all the last submission of a user
        public Submission getLastSubmissionForStudents(int subprojectID) {         

            var lastSubmission = (from x in db.Submissions
                                  join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                  join z in db.Users on y.UserID equals z.Id
                                  where subprojectID == x.SubprojectID
                                  orderby x.ID descending
                                  select x).FirstOrDefault();

            return lastSubmission;

        }

        //Returns the best submissions of all users who have submitted, that is, the most recent Accepted one, or the most recent non-Accepted one
        public List<Submission> getStudentsBestSubmission(int subprojectID)
        {
            var sub = new List<Submission>();

            foreach (var student in getStudentsThatHaveSubmitted(subprojectID))
            {
                var bestSubmission = (from x in db.Submissions
                                      join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                      where (subprojectID == x.SubprojectID && x.Accepted == true && student.Id == y.UserID)
                                      orderby x.SubmissionNr descending
                                      select x).FirstOrDefault();


                if (bestSubmission == null)
                {
                    sub.Add(getLastSubmissionForStudents(subprojectID));
                }
                else {
                    sub.Add(bestSubmission);
                }
            }

            return sub;
        }

        //Returns a list of the students that have made a submission
        public IEnumerable<ApplicationUser> getStudentsThatHaveSubmitted(int subprojectID)
        {
            var submittedStudents = (from x in db.Users
                                     join y in db.StudentSubmissions on x.Id equals y.UserID
                                     join z in db.Submissions on y.SubmissionID equals z.ID
                                     where z.SubprojectID == subprojectID
                                     select x).ToList().DistinctBy(d => d.Id);

            return submittedStudents;
        }

        //Adds a new submission to the database
        public void createSubmission(Submission submission, ApplicationUser user)
        {
            if(submission != null && user != null) {
                db.Submissions.Add(submission);
                db.SaveChanges();

                db.StudentSubmissions.Add(new StudentSubmission { UserID = user.Id, SubmissionID = submission.ID });
            }
        }

        //Updates the changes of a submission
        public void saveSubmissionChanges(int? submissionID)
        {
            Submission submission = getSubmissionById(submissionID.Value);

            if(submission != null) {
                db.Submissions.AddOrUpdate(submission);
                db.SaveChanges();
            }
        }

        //Returns the most recent submission by a student
        public Submission getMostRecentSubmission(ApplicationUser user, int subprojectID)
        {
            Submission submission = (from x in db.Submissions
                                     join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                     where user.Id == y.UserID && x.SubprojectID == subprojectID
                                     orderby x.SubmissionNr descending
                                     select x).FirstOrDefault();
            return submission;
        }

        //Returns a list of all the students who have submitted a certain subproject
        public IEnumerable<Submission> getStudentsSubmissionsForSubproject(string studentID)
        {
            IEnumerable<Submission> submissions = (from x in db.Users
                                                   join y in db.StudentSubmissions on x.Id equals y.UserID
                                                   join z in db.Submissions on y.SubmissionID equals z.ID
                                                   where x.Id == studentID
                                                   orderby z.SubmissionNr descending
                                                   select y.Submission) as IEnumerable<Submission>;  

            if(submissions != null) {
                return submissions;
            }

            return Enumerable.Empty<Submission>();
        }

        //Updates a subproject
        public Subproject ServiceEditSubproject(Subproject model)
        {
            Subproject subproject = (from item in db.Subprojects
                where item.ID == model.ID
                select item).SingleOrDefault();
            subproject.Name = model.Name;
            subproject.Description = model.Description;
            subproject.Grade = model.Grade;
            subproject.Input = model.Input;
            subproject.Output = model.Output;
            db.SaveChanges();

            return subproject;
        }

        //Updates a project
        public Project ServiceEditProject(Project model)
        {
            Project project = (from item in db.Projects
                               where item.ID == model.ID
                               select item).SingleOrDefault();

            project.Deadline = model.Deadline;
            project.GroupSize = model.GroupSize;
            project.Name = model.Name;
            project.Visibility = model.Visibility;
            db.SaveChanges();

            return project;
        }

        //Returns the creator of a submission
        public List<ApplicationUser> getStudentBySubmission(List<Submission> submissions)
        {
            List<ApplicationUser> users = new List<ApplicationUser>(); 
            foreach(var sub in submissions){
                var u = (from x in db.Users
                         join y in db.StudentSubmissions on x.Id equals y.UserID
                         where sub.ID == y.SubmissionID
                         select x).FirstOrDefault();
                users.Add(u); 
            }
            
            return users; 
        }

        //Updates the grade of a subproject 
        public void updateGrade(Submission submission)
        {
            if(submission != null)
            {
                Submission submissionToUpdate = db.Submissions.FirstOrDefault(x => x.ID == submission.ID);
                submissionToUpdate.Grade = submission.Grade;
                db.SaveChanges(); 
            }
        }

        //Returns the average grade for a project
        public double getGrade(int projectId, ApplicationUser student) {
            var subprojects = getSubprojects(projectId);
            var combinedPoints = 0; 

            foreach(var subp in subprojects) {
                var bestSubmission = (from x in db.Submissions
                                      join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                      where (subp.ID == x.SubprojectID && x.Accepted == true && student.Id == y.UserID)
                                      orderby x.SubmissionNr descending
                                      select x).FirstOrDefault();

                combinedPoints += bestSubmission.Grade;
            }
            var grade = combinedPoints / subprojects.Count;

            return grade;
        }
    }
}