using Mooshark2.Models;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Razor.Parser.SyntaxTree;
using Mooshark2.Models.DAL;
using Mooshark2.Models.ViewModels.TeacherViewModels;
using Microsoft.Ajax.Utilities;

namespace Mooshark2.Services
{
    public class ProjectService
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ProjectService()
        {
            db = new ApplicationDbContext();
        }


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

        public Project getProjectById(int projectID)
        {
            Project project = (from x in db.Projects
                               where projectID == x.ID
                               select x).SingleOrDefault(); 
            return project; 
        }

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

       public List<Subproject> getSubprojects(int projectID)
        {
            List<Subproject> subprojects = (from x in db.Subprojects
                                                   where projectID == x.ProjectID
                                                   select x).ToList();

           return subprojects;
        }

        public List<Submission> getSubmissions(int subprojectID)
        {
            List<Submission> submissions = (from x in db.Submissions
                                                   where subprojectID == x.SubprojectID
                                                   select x).ToList();

                return submissions;
        }


        public Subproject getSubprojectById(int subprojectID)
        {
            Subproject subproject = (from x in db.Subprojects
                                     where subprojectID == x.ID
                                     select x).SingleOrDefault();

            return subproject;
        }

        public Submission getSubmissionById(int submissionID)
        {
            Submission submission = (from x in db.Submissions
                                     where submissionID == x.ID
                                     select x).SingleOrDefault();
            return submission;
        }


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

        public IEnumerable<Project> getProjectsFromCourse(int courseID)
        {
            IEnumerable<Project> projectsFromCourse = (from x in db.Projects
                                                        where x.CourseID == courseID
                                                        select x) as IEnumerable<Project>;
            return projectsFromCourse;
        }


        public Submission getLastSubmissionForStudents(int subprojectID)
        {

            /*var groupByStudent = (from s in db.StudentSubmissions
                                  group s.SubmissionID by s.UserID
                                  into g
                                  select new { UserID = g.Key, Submissions = g.Max(x => x.) });

            var groupByStudent2 = db.StudentSubmissions.GroupBy(g => g.UserID)

            var lastSubmission = (from submission in groupByStudent
                                  orderby submission.Submissions descending
                                  select submission).FirstOrDefault();


            var lastSubmission2 = (from submission in db.Submissions
                                  join submitstudent in db.StudentSubmissions on submission.ID equals submitstudent.SubmissionID
                                  orderby submission.ID descending
                                  select submission).FirstOrDefault();*/

            /* var join = (from s in db.Submissions
                         join x in db.StudentSubmissions on s.SubprojectID equals x.)

             var lastSubmission = db.Submissions.Join(db.StudentSubmissions, y => y.SubprojectID == subprojectID).GroupBy(x => x.UserID).Select(s => s.OrderByDescending(i => i.SubmissionID).FirstOrDefault()));*/

            var lastSubmission = (from x in db.Submissions
                                  join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                  join z in db.Users on y.UserID equals z.Id
                                  where subprojectID == x.SubprojectID
                                  orderby x.ID descending
                                  select x).FirstOrDefault();

            return lastSubmission;

        }


        public List<Submission> getStudentsBestSubmission(int subprojectID)
        {
            var sub = new List<Submission>();

            foreach (var student in getStudentsThatHaveSubmitted(subprojectID))
            {
                var bestSubmission = (from x in db.Submissions
                                      join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                      join z in db.Users on y.UserID equals z.Id
                                      where (subprojectID == x.SubprojectID && x.Accepted == true)
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






        public IEnumerable<ApplicationUser> getStudentsThatHaveSubmitted(int subprojectID)
        {
            var submittedStudents = (from x in db.Users
                                     join y in db.StudentSubmissions on x.Id equals y.UserID
                                     join z in db.Submissions on y.SubmissionID equals z.ID
                                     where z.SubprojectID == subprojectID
                                     select x).ToList().DistinctBy(d => d.Id);




            /*var lastSubmission = db.StudentSubmissions.GroupBy(x => x.UserID).Select(s => s.Key);*/



            /*IEnumerable<ApplicationUser>submitedStudents = ( from x in db.Groups
                                                        join y in db.ProjectGroups on x.ID equals y.GroupID
                                                        join z in db.ProjectSubprojects on y.ProjectID equals z.ProjectID
                                                        join w in db.Submissions on z.SubprojectID equals w.SubprojectID
                                                        where x.UserID == userID && w.ID != 0
                                                        select x) as IEnumerable<ApplicationUser>;*/
            return submittedStudents;
        }

        public void createSubmission(Submission submission, ApplicationUser user)
        {
            if(submission != null && user != null) {
                db.Submissions.Add(submission);
                db.SaveChanges();

                db.StudentSubmissions.Add(new StudentSubmission { UserID = user.Id, SubmissionID = submission.ID });
            }
        }


        public void saveSubmissionChanges(int? submissionID)
        {
            Submission submission = getSubmissionById(submissionID.Value);

            if(submission != null) {
                db.Submissions.AddOrUpdate(submission);
                db.SaveChanges();
            }
        }

        public Submission getMostRecentSubmission(ApplicationUser user, int subprojectID)
        {
            Submission submission = (from x in db.Submissions
                                     join y in db.StudentSubmissions on x.ID equals y.SubmissionID
                                     where user.Id == y.UserID && x.SubprojectID == subprojectID
                                     orderby x.SubmissionNr descending
                                     select x).FirstOrDefault();
            return submission;
        }

        public IEnumerable<Submission> getStudentsSubmissionsForSubproject(string studentID)
        {
            IEnumerable<Submission> submissions = (from x in db.Users
                                                   join y in db.StudentSubmissions on x.Id equals y.UserID
                                                   join z in db.Submissions on y.SubmissionID equals z.ID
                                                   where x.Id == studentID
                                                   orderby z.SubmissionNr descending
                                                   select y.Submission) as IEnumerable<Submission>;  // OMG

            if(submissions != null) {
                return submissions;
            }

            return Enumerable.Empty<Submission>();
        }

        public InputOutput getIOBySubprojectId(int subprojectId)
        {
            InputOutput io = (from x in db.InputOutputs
                              where x.SubprojectID == subprojectId
                              select x).FirstOrDefault();
            return io; 
        }

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

        public void updateGrade(Submission submission)
        {
            if(submission != null)
            {
                db.Submissions.AddOrUpdate();
            }
        }
    }
}