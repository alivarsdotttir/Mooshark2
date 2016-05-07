using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherCourseViewModel
    {
        public Course course;
        public IEnumerable<Project> courseProjects;

        public TeacherCourseViewModel(Course c, IEnumerable<Project> p)
        {
            course = c;
            courseProjects = p;
        }
    }
}