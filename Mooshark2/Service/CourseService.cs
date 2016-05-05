using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;


namespace Mooshark2.Service
{
    public class CourseService
    {
        private ApplicationDbContext db;
        public CourseService()
        {
            db = new ApplicationDbContext();
        }


        //public List<Course> GetAllCourses()

        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = (from x in db.Courses
                           select x).ToList();
            return courses;
        }

    }
}