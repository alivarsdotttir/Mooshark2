using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;

/// <summary>
/// This class is a View Model for the Course View in Student Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentCourseViewModel
    {
        public Course currentCourse; 
        public IEnumerable<Project> projectsForCourse;
        public IEnumerable<ApplicationUser> teacherForCourse;

        public StudentCourseViewModel(Course course, IEnumerable<Project> projects, IEnumerable<ApplicationUser> teacher) 
        {
            currentCourse = course;
            projectsForCourse = projects;
            teacherForCourse = teacher; 
        }
    }
}