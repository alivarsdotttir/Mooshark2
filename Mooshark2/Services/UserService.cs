using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Notifications;
using Mooshark2.Models.DAL;


namespace Mooshark2.Services
{
    public class UserService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<SelectListItem> GetRoleList()
        {
            var allRoles = db.Roles.OrderBy(r => r.Name).ToList()
                                            .Select(
                                                x => new SelectListItem { Value = x.Name.ToString(), Text = x.Name })
                                            .ToList();

            return allRoles;
        }


        public List<SelectListItem> GetAllTeachers()
        {
            /* var allTeachers = (from user in db.Users
                                join rid in db.Roles on user.Id equals rid.Id 
                                where rid.Name.ToString() == "Teacher"
                                select user).ToList()
                                .Select( x=> new SelectListItem {
                                    Value = x.FullName.ToString(), Text = x.FullName
                                }).ToList();*/
            /*
                        var allTeachers = db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains("6e2bd1f6 - 9e19 - 4202 - b90f - c9c9957b7ecc")).ToList().Select(x => new SelectListItem
                        {
                            Value = x.FullName.ToString(),
                            Text = x.FullName
                        }).ToList();
            */
            /*  var allUsers = db.Users.OrderBy(r => r.FullName).ToList().Where(x => User(x.Id, "Teacher"))
                                              .Select(
                                                  x => new SelectListItem { Value = x.FullName.ToString(), Text = x.FullName })
                                              .ToList();*/

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var teacherRole = roleManager.FindByName("Teacher");
            var allTeachers = db.Users.Where(x => x.Roles.Any(s => s.RoleId == teacherRole.Id)).ToList().Select(
                                                  x => new SelectListItem { Value = x.Id, Text = x.FullName })
                                              .ToList();

            /*var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var teacherRole = roleManager.FindByName("Teacher");
            var allTeachers = db.Users.Where(x => x.Roles.Any(s => s.RoleId == teacherRole.Id)).ToList();*/

            return allTeachers;
        }

        public List<ApplicationUser> GetAllTeachersInCourse(int courseId)
        {
            var allTeachersInCourse = (from user in db.Users
                join c in db.CourseTeachers on user.Id equals c.UserID
                where c.CourseID == courseId
                select user).ToList();

            return allTeachersInCourse;

        }

        public List<SelectListItem> GetAllTeachersNotInCourse(int courseId)
        {
            var allTeachersNotInCourse = (from user in db.Users
                join c in db.CourseTeachers on user.Id equals c.UserID
                where c.CourseID != courseId
                select user).ToList().Select(
                    x => new SelectListItem { Value = x.Id, Text = x.FullName })
                .ToList();

            return allTeachersNotInCourse;
        }


        private bool User(string id, string v)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationUser> GetAllStudents()
        {
            /*var allStudents = (from user in db.Users
                               join rid in db.Roles on user.Id equals rid.Id
                               where rid.Name.ToString() == "Student"
                               select user).ToList();*/

            /*var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var studentRole = roleManager.FindByName("Student");
            var allStudents = db.Users.Where(x => x.Roles.Any(s => s.RoleId == studentRole.Id)).ToList();*/

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var studentRole = roleManager.FindByName("Student");
            var allStudents = db.Users.Where(x => x.Roles.Any(s => s.RoleId == studentRole.Id)).ToList();


            return allStudents;
        }

        public List<ApplicationUser> GetAllStudentsInCourse(int courseId)
        {
            var allStudentsInCourse = (from user in db.Users
                                       join c in db.CourseStudents on user.Id equals c.UserID
                                       where c.CourseID == courseId
                                       select user).ToList();

            return allStudentsInCourse;
        }

        public List<ApplicationUser> GetAllStudentsNotInCourse(int courseId)
        {
            var allStudentsNotInCourse = (from user in db.Users
                                       join c in db.CourseStudents on user.Id equals c.UserID
                                       where c.CourseID != courseId
                                       select user).ToList();

            return allStudentsNotInCourse;
        }


    }
}