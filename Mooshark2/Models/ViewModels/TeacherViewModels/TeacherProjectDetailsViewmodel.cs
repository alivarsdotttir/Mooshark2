using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is a View Model for the Project Details View in Teacher Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherProjectDetailsViewmodel
    {
        public Project currentProject
        {
            get;
            set;
        }
        public List<Subproject> subprojects
        {
            get;
            set;
        }

        public TeacherProjectDetailsViewmodel(Project cuPro, List<Subproject> sub)
        {
            currentProject = cuPro;
            subprojects = sub;
        }
            
    }
}