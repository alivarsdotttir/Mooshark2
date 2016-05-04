using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models;
using Mooshark2.Models.Entities;


namespace Mooshark2.Services
{
    public class CourseService
    {
        private ApplicationDbContext db;


        public CourseService()
        {
            db = new ApplicationDbContext();
        }


        public List<Course> getAllCourses()
        {
            var courses = (from x in db.Courses
                           select x).ToList();
            return courses;
        }
    }
}