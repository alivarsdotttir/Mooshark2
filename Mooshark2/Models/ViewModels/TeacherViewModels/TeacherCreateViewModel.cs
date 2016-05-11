using Mooshark2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.TeacherViewModels
{
    public class TeacherCreateViewModel
    {
        public Project project { get; set; }
        public IEnumerable<Subproject> manySubprojects { get; set; }
        public Subproject subproject { get; set; }
        public Course course { get; set; }
        //public InputOutput inputOutput;

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