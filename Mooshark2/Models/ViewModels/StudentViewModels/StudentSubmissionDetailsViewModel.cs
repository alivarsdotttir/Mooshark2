using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;

/// <summary>
/// This class is a View Model for the Submission Details View in Student Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentSubmissionDetailsViewModel
    {
        public Course currentCourse;
        public Project currentProject;
        public Subproject subproject;
        public Submission submission; 

        public StudentSubmissionDetailsViewModel(Course course, Project project, Subproject subp, Submission subm)
        {
            currentCourse = course;
            currentProject = project;
            subproject = subp;
            submission = subm; 
        }

        public StudentSubmissionDetailsViewModel()
        {

        }
    }
}