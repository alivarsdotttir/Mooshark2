using Microsoft.AspNet.Identity;
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



            //context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = new DateTime(2016, 6, 9, 0, 0, 0), Graded = false, Visibility = true, CourseID = 1 } );
            /*context.Roles.AddOrUpdate(r => r.Name,
             new IdentityRole { Name = "Admin" },
             new IdentityRole { Name = "Teacher" },
             new IdentityRole { Name = "Student" }
             );*/
             
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

            

           /* 
            context.Courses.AddOrUpdate(new Course { Active = true, Name = "Forritun 1" } );
            context.Courses.AddOrUpdate(new Course { Active = true, Name = "Gagnaskipan" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Reiknirit" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });*/

            /*
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("82252f05-fd4d-44bb-a72c-108a9c896223", "Teacher");
            context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "82252f05-fd4d-44bb-a72c-108a9c896223", CourseID = 1 });
            */
           // context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "82252f05-fd4d-44bb-a72c-108a9c896223", CourseID = 2 });

            //context.Users.AddOrUpdate(new ApplicationUser

            //8e052276 - b8a1 - 4d64 - ba81 - 796da1b0122c

            /*context.Courses.AddOrUpdate(new Course { Active = true, Name = "Vefforritun" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Stýrikerfi" });*/
            

            //context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = new DateTime(2017, 3, 9, 16, 5, 7, 123), Graded = false, Visibility = true, CourseID = 1 });
            /*context.Projects.AddOrUpdate(new Project { Name = "Project 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 1", Deadline = DateTime.Now, Graded = true, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 3 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 4 });
            */

            /*
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("258502b5-f20a-4e56-87bc-8acd6a405db0", "Admin");*/
            //context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 4 });*/
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //UserManager.AddToRole("258502b5-f20a-4e56-87bc-8acd6a405db0", "Admin");

            // add course-teacher connections

            context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "7f69729b-0d97-4a86-9493-505fbf2e693e", CourseID = 1 });
            //context.CourseStudents.AddOrUpdate(new CourseStudent { UserID = "e4a87126-62a5-4904-8359-61d11732dd53", CourseID = 1 });

            //context.Subprojects.AddOrUpdate(new Subproject { Name = "First part", Description = "This is the first part", ProjectID = 7, Weight = 50 });
            //context.Subprojects.AddOrUpdate( new Subproject { Name = "Second part", Description = "This is the second part", ProjectID = 7, Weight = 50 });
        }


    }


    }

