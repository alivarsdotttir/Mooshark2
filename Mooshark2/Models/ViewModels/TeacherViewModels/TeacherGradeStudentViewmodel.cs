using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherGradeStudentViewModel
    {
        public ApplicationUser currentStudent;
        public Project currentProject;
        // public IEnumerable<Submission> studentSubmissions;

        public TeacherGradeStudentViewModel(ApplicationUser c, Project p)
        {
            currentStudent = c;
            currentProject = p;
        }
    }
}