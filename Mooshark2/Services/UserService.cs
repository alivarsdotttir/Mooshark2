using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var allTeachers = (from user in db.Users
                               join rid in db.Roles on user.Id equals rid.Id // GÆTI VERIÐ VITLAUST ? hmm
                               where rid.Name.ToString() == "Teacher"
                               select user).ToList()
                               .Select( x=> new SelectListItem {
                                   Value = x.FullName.ToString(), Text = x.FullName
                               }).ToList();

            return allTeachers;
        }


        public IEnumerable<ApplicationUser> GetAllStudents()
        {
            var allStudents = (from user in db.Users
                               join rid in db.Roles on user.Id equals rid.Id
                               where rid.Name.ToString() == "Student"
                               select user).ToList();

            return allStudents;
        }

    }
}