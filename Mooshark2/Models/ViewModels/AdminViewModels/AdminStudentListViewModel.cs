using Mooshark2.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminStudentListViewModel
    {
        public IEnumerable<ApplicationUser> Students
        {
            get;
            set;
        }
        public AdminStudentListViewModel(IEnumerable<ApplicationUser> u)
        {
            Students = u;
        }

    }
}