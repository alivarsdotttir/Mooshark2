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

            /*context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });
            

            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });

            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Stýrikerfi" });
            */
            /*
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 1", Deadline = DateTime.Now, Graded = true, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Lab 2", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 2 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 3 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = DateTime.Now, Graded = false, Visibility = true, CourseID = 4 });
            */

            // add course-teacher connections
            //context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "6f47d062-a626-45a1-aad4-4957e1c1ebbd", CourseID = 1 });
            //context.CourseStudents.AddOrUpdate(new CourseStudent { UserID = "f9c37f8b-7133-4f32-ab2d-d85676d5eb90", CourseID = 1 });
        }


        }


    }

