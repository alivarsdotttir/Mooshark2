using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;
using Mooshark2.Models.ViewModels.AdminViewModels;

/// <summary>
/// This class is a connection to the database. It mainly concerns the courses. 
/// </summary>

namespace Mooshark2.Services
{
    public class CourseService
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public CourseService()
        {
            db = new ApplicationDbContext();
        }

        //Returns all the courses that exist in the database
        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = (from x in db.Courses
                                            select x).ToList();
            return courses;
        }

        //Creates a course, required from the Admin Controller
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

                db.SaveChanges();
                return true;
            }
        }

        //Updates database with new information regarding a course, required from the Admin Controller
        public void ServiceEditCourse(AdminCourseViewModel model)
        {
            Course course = (from item in db.Courses
                             where item.ID == model.Course.ID
                             select item).SingleOrDefault();

            course.Name = model.Course.Name;
            course.Active = model.Course.Active;

            if (model.Teacher.Id != null)
            {

                db.CourseTeachers.Add(new CourseTeacher { CourseID = model.Course.ID, UserID = model.Teacher.Id });

            }

            if (model.StudentListCheck != null)
            {
                foreach (var i in model.StudentListCheck)
                {
                    if (i.Checked == true)
                    {
                        db.CourseStudents.Add(new CourseStudent { CourseID = model.Course.ID, UserID = i.Student.Id });
                    }
                }
            }

            db.SaveChanges();

        }

        //Returns all the courses a certain user is assigned to 
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

        //Returns all the courses that a teacher is assigned to
        public IEnumerable<Course> getCoursesForTeacher(string teacherID)
        {
            var courses = (from x in db.Courses
                           join y in db.CourseTeachers on x.ID equals y.CourseID
                           where y.UserID == teacherID
                           select x) as IEnumerable<Course>;
            if(courses != null) {
                return courses;
            }

            return Enumerable.Empty<Course>();
        }

        //Returns a course with the same ID as the one that was sent as a parameter
        public Course getCourseById(int id)
        {
            Course course = (from x in db.Courses
                             where id == x.ID
                             select x).SingleOrDefault();
            
            return course;
        }

        //Returns the teachers assigned to a course
        public IEnumerable<ApplicationUser> getTeachersForCourse(int courseId)
        {
            var teachers = (from x in db.Users
                            join y in db.CourseTeachers on x.Id equals y.UserID
                            where y.CourseID == courseId
                            select x) as IEnumerable<ApplicationUser>;
            if(teachers != null) {
                return teachers;
            }

            return Enumerable.Empty<ApplicationUser>();
        }
        
        //Returns a list of the courses that respond to the projects that were sent in. 
        //Required from the Student and Teacher Index Views, where a table with both the projects and courses are displayed
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

            if(courses != null) {
                return courses;
            }

            return Enumerable.Empty<Course>();
        }

        //Updates the database connection table CourseTeachers. Erases the connection between a course and a teacher
        public void RemoveTeacherFromCourse(string userId, int courseId)
        {
            var teacherToRemove = db.CourseTeachers.SingleOrDefault(x => x.UserID == userId && x.CourseID == courseId);
            db.CourseTeachers.Remove(teacherToRemove);
            db.SaveChanges();
        }

        //Updates the database connection table CorseStudents. Erases the connection between a course and a student
        public void RemoveStudentFromCourse(string userId, int courseId)
        {
            var studentToRemove = db.CourseStudents.SingleOrDefault(x => x.UserID == userId && x.CourseID == courseId);
            db.CourseStudents.Remove(studentToRemove);
            db.SaveChanges();
        }
    }
}