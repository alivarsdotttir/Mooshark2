using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentSubmissionDetailsViewModel
    {
        public Course course;
        public Project project;
        public Subproject subproject;
        public Submission submission;
        //public InputOutput inputOutput; 

        public StudentSubmissionDetailsViewModel(Course c, Project p, Subproject subp, Submission subm)
        {
            course = c;
            project = p;
            subproject = subp;
            submission = subm;
            //inputOutput = io; 
        }

        public StudentSubmissionDetailsViewModel() { }
    }
}