using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherDetailsViewmodel
    {
        public Project currentProject;
        public IEnumerable<Subproject> subprojects;

        public TeacherDetailsViewmodel(Project c, IEnumerable<Subproject> sub)
        {
            currentProject = c;
            subprojects = sub;
        }
            
    }
}