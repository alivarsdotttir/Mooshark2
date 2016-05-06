using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminCourseViewModel
    {
        public IEnumerable<ApplicationUser> StudentList { get; set; }

        public AdminCourseViewModel(IEnumerable<ApplicationUser> s)
        {
            StudentList = s;
        }

    }
}