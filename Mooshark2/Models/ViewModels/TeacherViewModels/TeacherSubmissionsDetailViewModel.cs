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
        public Subproject currentSubproject;
        public Submission currentSubmission;


        public TeacherSubmissionsDetailViewModel()
        {

        }
        public TeacherSubmissionsDetailViewModel(ApplicationUser c, Subproject p, Submission s)
        {

            currentStudent = c;
            currentSubproject = p;
            currentSubmission = s;
        }
    }
}