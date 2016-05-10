using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mooshark2.Models.ViewModels.AdminViewModels
{
    public class AdminCourseViewModel
    {
        [Required]
        [Display(Name = "Course name")]
        public Course Course { get; set; }


        [Display(Name = "Teacher")]
        public ApplicationUser Teacher { get; set; }

        [Display(Name = "Teachers")]
        public IEnumerable<ApplicationUser> Teachers
        {
            get;
            set;
        }

        [Display(Name = "Students")]
        public IEnumerable<ApplicationUser> StudentList { get; set; }

        public AdminCourseViewModel(Course c, IEnumerable<ApplicationUser> p, IEnumerable<ApplicationUser> t)
        {
            Course = c;
            Teachers = p;
            StudentList = t;
        }

    }

  

}