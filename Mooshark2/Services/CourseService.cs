﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using Mooshark2.Models.ViewModels.AdminViewModels;


namespace Mooshark2.Services
{
    public class CourseService
    {
        private ApplicationDbContext db =  new ApplicationDbContext();

        public CourseService()
        {
            //db = new ApplicationDbContext();
        }


        public object ApplicationUser { get; private set; }

        //public List<Course> getAllCourses()

        //public IEnumerable<Course> getAllCourses()

        //public List<Course> GetAllCourses()

        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = (from x in db.Courses
                                            select x).ToList();
            return courses;
        }


        public bool ServiceCreateCourse(AdminCourseViewModel model)
        {
            if(db.Courses.Any(x => x.Name != model.Course.Name)) {
                db.Courses.Add(model.Course);
                /*foreach(var i in model.TeacherList) {
                    db.CourseTeachers.(i.Id, model.Course.ID);
                    db.CourseTeachers.
                }*/
                db.SaveChanges();
                return true;
            }
            else {
                return false;
            }
        }


        public IEnumerable<Course> getCoursesForStudent(string studentID)
        {
            var courses = (from x in db.Courses
                           join y in db.CourseStudents on x.ID equals y.CourseID
                           where studentID == y.UserID
                           select x) as IEnumerable<Course>;
            return courses; 
        }


        public IEnumerable<Course> getCoursesForTeacher(string teacherID)
        {
            var courses = (from x in db.CourseTeachers
                           join y in db.Courses on x.CourseID equals y.ID
                           where x.UserID == teacherID
                           select x) as IEnumerable<Course>;
            return courses;
        }

        public Course getCourseById(int id)
        {
            Course course = (from x in db.Courses
                             where id == x.ID
                             select x).SingleOrDefault();
            return course; 
        }

        public IEnumerable<ApplicationUser> getTeachersForCourse(int courseId)
        {
            var teachers = (from x in db.CourseTeachers
                            join y in db.Users on x.UserID equals y.Id
                            where x.CourseID == courseId
                            select x) as IEnumerable<ApplicationUser>;
            return teachers; 
        }
    }
}