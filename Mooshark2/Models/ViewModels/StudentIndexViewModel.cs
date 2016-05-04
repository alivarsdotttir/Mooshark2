using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels
{
    public class StudentIndexViewModel
    {
        private List<Project> upcomingProjects;
        private List<Course> coursesForStudents;

        public List<Course> CoursesForStudents
        {
            get
            {
                return coursesForStudents;
            }

            set
            {
                coursesForStudents = value;
            }
        }

        public List<Project> UpcomingProjects
        {
            get
            {
                return upcomingProjects;
            }

            set
            {
                upcomingProjects = value;
            }
        }
    }
}