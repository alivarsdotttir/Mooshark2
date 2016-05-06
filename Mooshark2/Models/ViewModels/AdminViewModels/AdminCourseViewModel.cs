using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;


namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminCourseViewModel
    {
        public IEnumerable<ApplicationUser> TeacherList { get; set; }
        public Course Course { get; set; }
        public IEnumerable<ApplicationUser> StudentList { get; set; }

        /*public AdminCourseViewModel(IEnumerable<ApplicationUser> t, Course c,IEnumerable<ApplicationUser> s)
        {
            TeacherList = t;
            Course = c;
            StudentList = s;
        }*/

    }
}