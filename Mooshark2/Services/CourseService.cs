using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using Mooshark2.Models.ViewModels.AdminViewModels;


namespace Mooshark2.Services
{
    public class CourseService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public CourseService()
        {
            db = new ApplicationDbContext();
        }


        public object ApplicationUser { get; private set; }


        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = (from x in db.Courses
                                            select x).ToList();
            return courses;
        }


        public bool ServiceCreateCourse(AdminCourseViewModel model)
        {
            if (db.Courses.Any(x => x.Name == model.Course.Name))
            {

                return false;
            }
            else {
                db.Courses.Add(model.Course);

                if (model.Teacher.Id != null)
                {

                    db.CourseTeachers.Add(new CourseTeacher { CourseID = model.Course.ID, UserID = model.Teacher.Id });

                }

                if (model.StudentListCheck != null) {
                    foreach(var i in model.StudentListCheck) {
                        if(i.Checked == true) {
                            db.CourseStudents.Add(new CourseStudent { CourseID = model.Course.ID, UserID = i.Student.Id });
                        }
                    }
                }
                /* foreach (var i in model.StudentList)
                    {
                        db.CourseStudents.AddOrUpdate(new CourseStudent { CourseID = model.Course.ID, UserID = i.Id });
                    }*/

                db.SaveChanges();
                return true;
            }
        }

        public void ServiceEditCourse(AdminCourseViewModel model)
        {
            Course course = (from item in db.Courses
                             where item.ID == model.Course.ID
                             select item).SingleOrDefault();

            model.Course.Name = course.Name;
            model.Course.Active = course.Active;

            if (model.Teacher.Id != null)
            {

                db.CourseTeachers.Add(new CourseTeacher { CourseID = model.Course.ID, UserID = model.Teacher.Id });

            }

            db.SaveChanges();

        }


        public IEnumerable<Course> getCoursesForStudent(string studentID)
        {
            var courses = (from x in db.Courses
                           join y in db.CourseStudents on x.ID equals y.CourseID
                           where studentID == y.UserID
                           select x) as IEnumerable<Course>;
            if (courses != null)
            {
                return courses;
            }
            return Enumerable.Empty<Course>();
        }


        public IEnumerable<Course> getCoursesForTeacher(string teacherID)
        {
            var courses = (from x in db.Courses
                           join y in db.CourseTeachers on x.ID equals y.CourseID
                           where y.UserID == teacherID
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
            var teachers = (from x in db.Users
                            join y in db.CourseTeachers on x.Id equals y.UserID
                            where y.CourseID == courseId
                            select x) as IEnumerable<ApplicationUser>;
            return teachers; 
        }

        public IEnumerable<Course> getCoursesForMultipleProjects(IEnumerable<Project> projects)
        {
            IEnumerable<Course> courses = null; 
            foreach(Project project in projects)
            {
                if(courses == null)
                {
                    courses = (from x in db.Courses
                               where x.ID == project.CourseID
                               select x) as IEnumerable<Course>; 
                }
                else
                {
                    courses = courses.Concat(from x in db.Courses
                                             where x.ID == project.CourseID
                                             select x) as IEnumerable<Course>;
                }
            }
            return courses; 
        }

        
    }
}