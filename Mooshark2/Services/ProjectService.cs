using Mooshark2.Models;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Services
{
    public class ProjectService
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ProjectService()
        {
            db = new ApplicationDbContext();
        }

        public bool ServiceCreatProject(Project project)
        {
            if (db.Projects.Any(x => x.Name != project.Name))
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Project> getUpcomingProjects(IEnumerable<Course> studentCourses)
        {
            if (!studentCourses.Any())
            {
                IEnumerable<Project> upcomingProjects = null;
                foreach (Course course in studentCourses)
                {
                    upcomingProjects = upcomingProjects.Concat(from x in db.Projects
                                                               where x.CourseID == course.ID && DateTime.Now < x.Deadline && x.Visibility == true
                                                               orderby x.Deadline ascending
                                                               select x) as IEnumerable<Project>;
                }
                return upcomingProjects;
            }
            else
                return null; 
        }

        public IEnumerable<Project> getProjectsForCourse(int courseID)
        {
            IEnumerable<Project> projects = (from x in db.Projects
                                             where x.CourseID == courseID && x.Visibility == true && DateTime.Now < x.Deadline
                                             select x) as IEnumerable<Project>;
            return projects; 
        }

        public Project getProjectById(int projectID)
        {
            Project project = (from x in db.Projects
                               where projectID == x.ID
                               select x).SingleOrDefault(); 
            return project; 
        }

        public IEnumerable<Subproject> getSubprojects(int projectID)
        {
            IEnumerable<Subproject> subprojects = (from x in db.Subprojects
                                                   where projectID == x.ProjectID
                                                   select x) as IEnumerable<Subproject>;
            return subprojects; 
        }

        public IEnumerable<Submission> getSubmissions(int subprojectID)
        {
            IEnumerable<Submission> submissions = (from x in db.Submissions
                                                   where subprojectID == x.SubprojectID
                                                   select x) as IEnumerable<Submission>;
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
            return ungradedProjects;
        }

        public IEnumerable<Project> getProjectsFromCourse(int courseID)
        {
            IEnumerable<Project> projectsFromCourse = (from x in db.Projects
                                                        where x.CourseID == courseID
                                                        select x) as IEnumerable<Project>;
            return projectsFromCourse;
        }

        /*public IEnumerable<Subproject> getProjectDescription()
        {
           IEnumerable<Subproject>projectDescription = (from x in db.Subprojects 
                                                         where x.Description == )
        }*/
    }
}