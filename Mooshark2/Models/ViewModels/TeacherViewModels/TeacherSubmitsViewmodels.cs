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
        private IEnumerable<Submission> mostRecentSubmission;
        private object students;

        public TeacherSubmitsViewmodels(IEnumerable<Submission> mostRecentSubmission, object students)
        {
            this.mostRecentSubmission = mostRecentSubmission;
            this.students = students;
        }

        public TeacherSubmitsViewmodels(IEnumerable<Submission> curr, IEnumerable<ApplicationUser>list)
        {
            currentProjects = curr;
            listOfSubmittedStudents = list;
        }
    }
}