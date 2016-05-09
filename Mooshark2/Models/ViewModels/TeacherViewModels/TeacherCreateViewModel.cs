using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherCreateViewModel
    {
        public Project project;
        public Subproject subproject;
        public IEnumerable<Subproject> subprojects;
        public Course course;

        public TeacherCreateViewModel(Project p, IEnumerable<Subproject> s, Course c)
        {
            project = p;
            subprojects = s;
            course = c;
        }
    }
}