using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherSubmitsViewmodels
    {
        public IEnumerable<Submission> currentProjects;
        public IEnumerable<ApplicationUser> listOfSubmittedStudents;

        public TeacherSubmitsViewmodels(IEnumerable<Submission> curr, IEnumerable<ApplicationUser>list)
        {
            currentProjects = curr;
            listOfSubmittedStudents = list;
        }
    }
}