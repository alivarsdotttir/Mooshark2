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
        private List<ApplicationUser> students;
        private List<ApplicationUser> studentsNotInCourse;

        [Required]
        [Display(Name = "Course name")]
        public Course Course { get; set; }
        [Display(Name = "Teacher")]
        public ApplicationUser Teacher { get; set; }
        [Display(Name = "Teachers")]
        public IEnumerable<ApplicationUser> Teachers { get; set; }
        public IEnumerable<ApplicationUser> StudentList { get; set; }
        [Display(Name = "Students")]
        public List<AdminSelectStudentViewModel> StudentListCheck { get; set; }

        public AdminCourseViewModel(Course course, IEnumerable<ApplicationUser> teacher, IEnumerable<ApplicationUser> listOfStudents, List<AdminSelectStudentViewModel> studentList)
        {
            Course = course;
            Teachers = teacher;
            StudentList = listOfStudents;
            StudentListCheck = studentList;
        }


        public AdminCourseViewModel(List<AdminSelectStudentViewModel> studentList)
        {
            StudentListCheck = studentList;
        }


        public AdminCourseViewModel()
        {
            
        }
    }
}