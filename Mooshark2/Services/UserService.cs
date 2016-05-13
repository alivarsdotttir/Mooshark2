using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Notifications;
using Mooshark2.Models.DAL;
using Mooshark2.Models.ViewModels.AdminViewModels;

/// <summary>
/// This class is a connection to the database. It mainly concerns the admins, teachers and students. 
/// </summary>
/// 
namespace Mooshark2.Services
{
    public class UserService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //Returns the roles that users can have, that is admin, teacher or student
        public List<SelectListItem> GetRoleList()
        {
            var allRoles = db.Roles.OrderBy(r => r.Name).ToList()
                                            .Select(
                                                x => new SelectListItem { Value = x.Name.ToString(), Text = x.Name })
                                            .ToList();

            return allRoles;
        }

        //Returns all existing teachers
        public List<SelectListItem> GetAllTeachers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var teacherRole = roleManager.FindByName("Teacher");
            var allTeachers = db.Users.Where(x => x.Roles.Any(s => s.RoleId == teacherRole.Id)).ToList().Select(
                                                  x => new SelectListItem { Value = x.Id, Text = x.FullName })
                                              .ToList();
            return allTeachers;
        }

        //Returns all teachers that manage a course
        public List<ApplicationUser> GetAllTeachersInCourse(int courseId)
        {
            var allTeachersInCourse = (from user in db.Users
                join c in db.CourseTeachers on user.Id equals c.UserID
                where c.CourseID == courseId
                select user).ToList();

            return allTeachersInCourse;

        }

        //Returns all users in the database
        public List<ApplicationUser> GetAllUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var allUsers = (from x in db.Users
                            select x).ToList();

            return allUsers;   
        }

        //Returns all the teachers that are not currently managing a course.
        //Required for adding teachers to a course
        public List<SelectListItem> GetAllTeachersNotInCourse(int courseId)
        {
            var allTeachersInCourse = GetAllTeachersInCourse(courseId).ToList();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var teacherRole = roleManager.FindByName("Teacher");
            var allTeachers = db.Users.Where(x => x.Roles.Any(s => s.RoleId == teacherRole.Id)).ToList();                
                

            var result = allTeachers.Where(x => !allTeachersInCourse.Contains(x)).ToList().Select(y => new SelectListItem { Value = y.Id, Text = y.FullName}).ToList();

            return result;
        }

        //Returns all existing students
        public List<ApplicationUser> GetAllStudents()
        {    
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var studentRole = roleManager.FindByName("Student");
            var allStudents = db.Users.Where(x => x.Roles.Any(s => s.RoleId == studentRole.Id)).ToList();


            return allStudents;
        }
            
        //Returns all existing students, required for a select list
        public List<AdminSelectStudentViewModel> GetAllStudentsUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var studentRole = roleManager.FindByName("Student");
            var allStudents =
                db.Users.Where(x => x.Roles.Any(s => s.RoleId == studentRole.Id))
                  .ToList()
                  .Select(y => new AdminSelectStudentViewModel { Student = y , Checked = false }).ToList();

            return allStudents;

        }

        //Returns a certain user, who'se ID matches the one passed in as a parameter
        public ApplicationUser getUserById(string userId)
        {
            ApplicationUser user = (from x in db.Users
                                    where x.Id == userId
                                    select x).FirstOrDefault();

            return user;
        }

        //Returns all the courses assigned to a certain course
        public List<ApplicationUser> GetAllStudentsInCourse(int courseId)
        {
            var allStudentsInCourse = (from user in db.Users
                                       join c in db.CourseStudents on user.Id equals c.UserID
                                       where c.CourseID == courseId
                                       select user).ToList();

            return allStudentsInCourse;
        }

        //Returns all the students in course, required for a select list
        public List<SelectListItem> GetAllStudentsInCourseSelectList(int courseId)
        {
            var allStudentsInCourse = (from user in db.Users
                                       join c in db.CourseStudents on user.Id equals c.UserID
                                       where c.CourseID == courseId
                                       select user).ToList().Select(y => new SelectListItem { Value = y.Id, Text = y.FullName }).ToList();

            return allStudentsInCourse;
        }

        //Returns all the students currently not assigned to a certain course
        public List<AdminSelectStudentViewModel> GetAllStudentsNotInCourse(int courseId)
        {
            var allStudentsInCourse = GetAllStudentsInCourse(courseId);
            var allStudents = GetAllStudents();

            var allStudentsNotInCourse = allStudents.Where(x => !allStudentsInCourse.Contains(x)).ToList().Select(y => new AdminSelectStudentViewModel { Student = y, Checked = false }).ToList();

            return allStudentsNotInCourse;

        }

        //Updates an already existing user
        public ApplicationUser ServiceEditUser(ApplicationUser model)
        {
            ApplicationUser user = (from item in db.Users
                                    where item.Id == model.Id
                                    select item).SingleOrDefault();

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.SSN = model.SSN;
            user.Email = model.Email;
            db.SaveChanges();

            return user;

        }

    }
}