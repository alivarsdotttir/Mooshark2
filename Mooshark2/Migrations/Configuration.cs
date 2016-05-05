using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.DAL;


namespace Mooshark2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Mooshark2.Models.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Mooshark2.Models.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Teacher" },
                new IdentityRole { Name = "Student" });
            
            
            context.Users.AddOrUpdate( new ApplicationUser { UserName = "admin", Email = "admin@admin.is", PasswordHash = "Admin.123",
                                       EmailConfirmed  = false, PhoneNumberConfirmed  = false, TwoFactorEnabled = false, LockoutEnabled = false,
                                       AccessFailedCount = 0});

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
