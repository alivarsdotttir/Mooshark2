﻿using System;
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

        public object ApplicationUser { get; private set; }

        public List<Course> getAllCourses()
        {
            var courses = (from x in db.Courses
                           select x).ToList();
            return courses;
        }

        public IEnumerable<Course> getCoursesForTeacher(ApplicationUser Teacher)
        {
            var courses = (from x in db.CourseTeachers
                           join y in db.Courses on x.CourseID equals y.ID
                           where x.UserID == Teacher.Id
                           select x) as IEnumerable<Course>;
            return courses;
        }
    }
}