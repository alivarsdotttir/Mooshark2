using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is a View Model for the SubmissionDetails View in Teacher Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherSubmissionsDetailViewModel
    {
        public ApplicationUser currentStudent { get; set; }
        public Subproject currentSubproject { get; set; }

        public Submission currentSubmission { get; set; }


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