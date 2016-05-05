using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.DAL;


namespace Mooshark2.Services
{
    public class UserService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<SelectListItem> GetRoleList()
        {
            var allRoles = (db).Roles.OrderBy(r => r.Name).ToList()
                                            .Select(
                                                x => new SelectListItem { Value = x.Name.ToString(), Text = x.Name })
                                            .ToList();

            return allRoles;
        }

    }
}