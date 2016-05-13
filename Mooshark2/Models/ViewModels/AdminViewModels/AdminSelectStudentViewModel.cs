using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;

/// <summary>
/// This class is a View Model for the SelectStudent View in Admin Controller
/// </summary>
namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminSelectStudentViewModel
    {
        public ApplicationUser Student { get; set; }
        public bool Checked { get; set; }

        public AdminSelectStudentViewModel(ApplicationUser student)
        {
            Student = student;
            Checked = false;
        }


        public AdminSelectStudentViewModel()
        {
            Checked = false;
        }
    }
}