using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherCourseVieweModel
    {
        Course course;
        IEnumerable<Project> courseProjects;

        public TeacherCourseVieweModel(Course c, IEnumerable<Project> p)
        {
            course = c;
            courseProjects = p;
        }
    }
}