using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherSubmissionsDetailViewModel
    {
        public ApplicationUser currentStudent;
        public Project currentProject;
        public IEnumerable<Submission> currentStudentsSubmissions;

        public TeacherSubmissionsDetailViewModel(ApplicationUser c, Project p, IEnumerable<Submission> s)
        {

            currentStudent = c;
            currentProject = p;
            currentStudentsSubmissions = s;
        }
    }
}