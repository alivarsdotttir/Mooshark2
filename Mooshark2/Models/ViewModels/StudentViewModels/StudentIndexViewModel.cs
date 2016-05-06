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

        public StudentIndexViewModel(IEnumerable<Project> p, IEnumerable<Course> cfp, IEnumerable<Course> c)
        {
            upcomingProjects = p;
            coursesForProjects = cfp; 
            coursesForStudents = c; 
        }
    }
}