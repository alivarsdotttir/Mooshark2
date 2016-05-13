using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentIndexViewModel
    {
        public IEnumerable<Project> upcomingProjects;
        public IEnumerable<Course> coursesForProjects;
        public IEnumerable<Course> coursesForStudents;

        public StudentIndexViewModel(IEnumerable<Project> projects, IEnumerable<Course> coursesForP, IEnumerable<Course> coursesForS)
        {
            upcomingProjects = projects;
            coursesForProjects = coursesForP; 
            coursesForStudents = coursesForS; 
        }
    }
}