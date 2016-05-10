using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherProjectDetailsViewmodel
    {
        public Project currentProject;
        public IEnumerable<Subproject> subprojects;
        public Course currentCourse;

        public TeacherProjectDetailsViewmodel(Project cuPro, IEnumerable<Subproject> sub, Course cuCo)
        {
            currentProject = cuPro;
            subprojects = sub;
            currentCourse = cuCo;
        }
            
    }
}