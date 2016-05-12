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
        public IEnumerable<Subproject> subprojects; 
        public IEnumerable<Submission> projectSubmissions;
        public Course currentCourse;

        public StudentDetailsViewModel(Project p, IEnumerable<Subproject> sp, IEnumerable<Submission> sm, Course c)
        {
            currentProject = p;
            subprojects = sp;
            projectSubmissions = sm;
            currentCourse = c;
        }


        public StudentDetailsViewModel() { }
    }
}