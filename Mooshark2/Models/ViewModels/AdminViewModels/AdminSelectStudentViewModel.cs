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

    }
}