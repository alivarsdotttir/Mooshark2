using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.DAL;
using Mooshark2.Models.Entities;


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
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Mooshark2.Models.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version
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

            /*context.Courses.AddOrUpdate(new Course { Active = true, Name = "Forritun 1" } );
            context.Courses.AddOrUpdate(new Course { Active = true, Name = "Gagnaskipan" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Reiknirit" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });*/

            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.is",
                PasswordHash = "Admin.1234",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });


            //8e052276 - b8a1 - 4d64 - ba81 - 796da1b0122c
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Stýrikerfi" });

            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 1", Deadline = DateTime.Now, Graded = true, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 3 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 4 });

        }

        /*context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@admin.is",
                PasswordHash = "Admin.123",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FullName = "Admin Adminsson",
                SSN = "0101660169"
            });*/

    }
}
