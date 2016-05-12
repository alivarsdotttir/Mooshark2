﻿using Mooshark2.Models.DAL;
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
        public IEnumerable<StudentSubmission> lastSubmissions;
        public IEnumerable<Submission> bestSubmissions;
        public Subproject currentSubproject;

        public TeacherSubmissionsViewmodel(IEnumerable<Submission> all, IEnumerable<ApplicationUser> stuSub, IEnumerable<Submission> mReSub, Subproject subPro, IEnumerable<StudentSubmission> last)
        {
            allSubmissionsForSubproject = all;
            studentsThatHaveSubmitted = stuSub;
            bestSubmissions = mReSub;
            currentSubproject = subPro;
            lastSubmissions = last;
        }
    }
}