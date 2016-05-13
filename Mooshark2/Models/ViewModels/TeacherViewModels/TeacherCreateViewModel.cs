using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is a View Model for the Create (Project) View in Teacher Controller
/// </summary>

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherCreateViewModel
    {
        public Project project { get; set; }
        public IEnumerable<Subproject> manySubprojects { get; set; }
        public Subproject subproject { get; set; }
        public Course course { get; set; }
        public InputOutput inputoutput;

        public TeacherCreateViewModel(Course c)
        {
            course = c;
            //inputOutput = i;
        }


        public TeacherCreateViewModel()
        {
            
        }
    }
}