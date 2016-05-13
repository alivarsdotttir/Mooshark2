using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentSubmitViewModel
    {
        public Project currentProject;
        public Subproject subproject; 

        public StudentSubmitViewModel(Project project, Subproject subp)
        {
            currentProject = project;
            subproject = subp; 
        }
    }
}