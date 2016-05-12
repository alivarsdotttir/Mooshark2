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

        public StudentDetailsViewModel(Project p, List<Subproject> sp, List<Submission> sm, Course c)
        {
            currentProject = p;
            subprojects = sp;
            projectSubmissions = sm;
            currentCourse = c;
        }


        public StudentDetailsViewModel() { }
    }
}