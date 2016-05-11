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
        public Submission submission;
        public InputOutput inputOutput; 

        public StudentSubmissionDetailsViewModel(Course c, Project p, Submission s, InputOutput io)
        {
            course = c;
            project = p;
            submission = s;
            inputOutput = io; 
        }
    }
}