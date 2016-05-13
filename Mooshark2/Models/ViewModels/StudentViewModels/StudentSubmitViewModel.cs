using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentSubmitViewModel
    {
        public Project currentProject;
        public Subproject subproject;
        public List<ApplicationUser> students;

        public StudentSubmitViewModel(Project project, Subproject subp, List<ApplicationUser> us )
        {
            currentProject = project;
            subproject = subp;
            students = us;
        }


        public StudentSubmitViewModel()
        {
            
        }

    }
}