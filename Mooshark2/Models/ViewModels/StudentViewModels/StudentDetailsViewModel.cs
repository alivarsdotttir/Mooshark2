using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels
{
    public class StudentDetailsViewModel
    {
        Project currentProject;
        IEnumerable<Subproject> subprojects; 
        IEnumerable<Submission> projectSubmissions;

        public StudentDetailsViewModel(Project p, IEnumerable<Subproject> sp, IEnumerable<Submission> sm)
        {
            currentProject = p;
            subprojects = sp;
            projectSubmissions = sm; 
        }
        
    }
}