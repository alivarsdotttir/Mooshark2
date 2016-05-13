using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is a View Model for the Index View in Teacher Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherIndexViewmodel
    {
        public IEnumerable<Project> ungradedProjects;
        public IEnumerable<Course> coursesForProjects;
        public IEnumerable<Course> coursesForTeacher;

        public TeacherIndexViewmodel(IEnumerable<Project>u,IEnumerable<Course>cp, IEnumerable<Course>c)
        {
            ungradedProjects = u;
            coursesForProjects = cp;
            coursesForTeacher = c;
        }  
    }
}