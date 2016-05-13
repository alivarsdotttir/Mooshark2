using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;

/// <summary>
/// This class is a View Model for the StudentSubmissions View in Teacher Controller
/// </summary>


namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherStudentSubmissionsViewModel
    {
        public ApplicationUser student;
        public Subproject subproject;
        public IEnumerable<Submission> submissions; 

        public TeacherStudentSubmissionsViewModel(ApplicationUser s, Subproject subp, IEnumerable<Submission> subm)
        {
            student = s;
            subproject = subp;
            submissions = subm; 
        }
    }
}