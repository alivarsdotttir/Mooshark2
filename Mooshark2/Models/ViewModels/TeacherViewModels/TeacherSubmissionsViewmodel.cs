using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherSubmissionsViewmodel
    {
        public IEnumerable<Submission> allSubmissionsForSubproject;
        public IEnumerable<ApplicationUser> studentsThatHaveSubmitted;
        //public IEnumerable<StudentSubmission> lastSubmissions;
        public List<Submission> bestSubmissions;
        public Subproject currentSubproject;

        public TeacherSubmissionsViewmodel(IEnumerable<Submission> all, IEnumerable<ApplicationUser> stuSub, List<Submission> best, Subproject subPro)
        {
            allSubmissionsForSubproject = all;
            studentsThatHaveSubmitted = stuSub;
            bestSubmissions = best;
            currentSubproject = subPro;
            //lastSubmissions = last;
        }
    }
}