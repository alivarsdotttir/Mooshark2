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
        private ApplicationDbContext db;


        public ProjectService()
        {
            db = new ApplicationDbContext();
        }

        public IEnumerable<Project> getUpcomingProjects(IEnumerable<Course> studentCourses)
        {
            if (!studentCourses.Any())
            {
                IEnumerable<Project> upcomingProjects = null;
                foreach (Course course in studentCourses)
                {
                    upcomingProjects = upcomingProjects.Concat(from x in db.Projects
                                                               where x.CourseID == course.ID && DateTime.Now < x.Deadline
                                                               select x) as IEnumerable<Project>;
                }
                return upcomingProjects;
            }
            else
                return null; 
        }
    }
}