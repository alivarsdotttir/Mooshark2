using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is a View Model for the Submissions View in Teacher Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherSubmissionsViewmodel
    {
        public IEnumerable<Submission> allSubmissionsForSubproject;
        public IEnumerable<ApplicationUser> studentsThatHaveSubmitted;
        
        //public IEnumerable<StudentSubmission> lastSubmissions;
        public List<Submission> bestSubmissions;
        public List<ApplicationUser> usersForSubmissions; 
        public Subproject currentSubproject;



        public TeacherSubmissionsViewmodel(IEnumerable<Submission> all, IEnumerable<ApplicationUser> stuSub, List<Submission> best, List<ApplicationUser> usersForSub, Subproject subPro)
        {
            allSubmissionsForSubproject = all;
            studentsThatHaveSubmitted = stuSub;
            bestSubmissions = best;
            usersForSubmissions = usersForSub;
            currentSubproject = subPro;
            //lastSubmissions = last;

        }
    }
}