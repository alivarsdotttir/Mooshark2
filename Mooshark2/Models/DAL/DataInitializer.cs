using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Mooshark2.Models.DAL
{
    public class DataInitializer  : System.Data.Entity.CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {   /*
            Roles.CreateRole("Admin");
            Roles.CreateRole("Teacher");
            Roles.CreateRole("Student");
            */

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var str = RoleManager.Create(new IdentityRole("Admin"));

            var admin = new ApplicationUser {Id = "010166-0169", UserName = "admin", Email = "admin@admin.is", Roles = { }, };
          
        }
    }
}