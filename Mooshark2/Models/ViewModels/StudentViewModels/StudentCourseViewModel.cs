using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.ViewModels
{
    public class StudentCourseViewModel
    {
        Course course; 
        IEnumerable<Project> projectsForCourse;
        IEnumerable<ApplicationUser> teacherForCourse;

        public StudentCourseViewModel(Course c, IEnumerable<Project> p, IEnumerable<ApplicationUser> t) 
        {
            course = c;
            projectsForCourse = p;
            teacherForCourse = t; 
        }
    }
}