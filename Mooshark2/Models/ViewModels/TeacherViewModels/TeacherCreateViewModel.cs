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

        public TeacherCreateViewModel(Project p, Subproject s)
        {
            project = p;
            subproject = s;
        }
    }
}