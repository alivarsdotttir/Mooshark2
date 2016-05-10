using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;


namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminSelectStudentViewModel
    {
        public ApplicationUser Student { get; set; }
        public bool Checked { get; set; }


        public AdminSelectStudentViewModel(ApplicationUser u)
        {
            Student = u;
            Checked = false;
        }


        /*public IList<AdminSelectStudentViewModel> createAdminSelectStudents(List<ApplicationUser> list)
        {
            IList<AdminSelectStudentViewModel> returnList = new List<AdminSelectStudentViewModel>();
            foreach(var student in list) {
                returnList.Add(new AdminSelectStudentViewModel {
                    Student = student, Checked = false
                });

            }

            return returnList;
        }*/


        public AdminSelectStudentViewModel()
        {
            Checked = false;
        }


    }
}