using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels.StudentViewModels
{
    public class StudentDetailsViewModel
    {
        public Project currentProject;
        public List<Subproject> subprojects; 
        public List<Submission> projectSubmissions;
        public Course currentCourse;

        public StudentDetailsViewModel(Project project, List<Subproject> subs, List<Submission> submissions, Course course)
        {
            currentProject = project;
            subprojects = subs;
            projectSubmissions = submissions;
            currentCourse = course;
        }


        public StudentDetailsViewModel() { }
    }
}