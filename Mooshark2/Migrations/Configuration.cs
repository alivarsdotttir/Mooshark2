namespace Mooshark2.Migrations
{
    using Models.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.DAL;
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

            //context.Projects.AddOrUpdate(new Project { Name = "lab 2", CourseID = 1, Deadline = new DateTime(2013, 9, 20, 17, 45, 00), Graded = false, isGroupProject = false, Visibility = true, Grade = 10});
            //context.Projects.AddOrUpdate(new Project { Name = "lab 1", CourseID = 2, Deadline = new DateTime(2013, 9, 20, 17, 45, 00), Graded = false, isGroupProject = false, Visibility = true, Grade = 10 });
            //context.Projects.AddOrUpdate(new Project { Name = "lab 2", CourseID = 2, Deadline = new DateTime(2013, 9, 20, 17, 45, 00), Graded = false, isGroupProject = false, Visibility = true, Grade = 10 });
            //context.Projects.AddOrUpdate(new Project { Name = "lab 2", CourseID = 3, Deadline = new DateTime(2013, 9, 20, 17, 45, 00), Graded = false, isGroupProject = false, Visibility = true, Grade = 10 });
            //context.Projects.AddOrUpdate(new Project { Name = "lab 1", CourseID = 3, Deadline = new DateTime(2013, 9, 20, 17, 45, 00), Graded = false, isGroupProject = false, Visibility = true, Grade = 10 });
            //context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "7f69729b-0d97-4a86-9493-505fbf2e693e", CourseID =2 });
            //context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "7f69729b - 0d97 - 4a86 - 9493 - 505fbf2e693e", CourseID = 2 });
            //context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "7f69729b-0d97-4a86-9493-505fbf2e693e", CourseID = 3 });

            // add course-teacher connections
            //context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = , CourseID = });

            /*context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Teacher" },
                new IdentityRole { Name = "Student" }); */
            //  This method will be called after migrating to the latest version.

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
            context.Courses.AddOrUpdate(new Course { Active = true, Name = "Forritun 1" });
            context.Courses.AddOrUpdate(new Course { Active = true, Name = "Gagnaskipan" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Reiknirit" });
            context.Courses.AddOrUpdate(new Course { Active = false, Name = "Vefforritun" });
            */
            /*
            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = new DateTime(2017, 3, 9, 0, 0, 0), Graded = false, Visibility = true, CourseID = 1 });
            context.Projects.AddOrUpdate(new Project { Name = "Project 2", Deadline = new DateTime(2017, 3, 9, 0, 0, 0), Graded = false, Visibility = true, CourseID = 2 });
            */
            /*
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "teacher",
                Email = "teacher@teacher.is",
                PasswordHash = "Teacher.123",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FullName = "Teacher Teachersson",
                SSN = "0101660169"
            });
            */
            /*
            context.Users.AddOrUpdate(new ApplicationUser
            {
                UserName = "tinnats15",
                Email = "tinnats15@ru.is",
                PasswordHash = "Tinna.123",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FullName = "Tinna Þuríður Sigurðardóttir",
                SSN = "0106902859"
            });*/
            /*
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole("e427af15-2cde-48cc-a976-2a1662a4a4bd", "Student");
            UserManager.AddToRole("842a4227-59b8-4ff2-9aeb-4c80fe22c797", "Teacher");
            
            
            /*context.CourseStudents.AddOrUpdate(new CourseStudent { UserID = "3d08cbf7-7730-484c-9c02-3356f8cf2b1d", CourseID = 1 });
            context.CourseStudents.AddOrUpdate(new CourseStudent { UserID = "3d08cbf7-7730-484c-9c02-3356f8cf2b1d", CourseID = 2 });*/
            /*
            context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "842a4227-59b8-4ff2-9aeb-4c80fe22c797", CourseID = 1});
            context.CourseTeachers.AddOrUpdate(new CourseTeacher { UserID = "842a4227-59b8-4ff2-9aeb-4c80fe22c797", CourseID = 2});
            */
            /*
            context.Subprojects.AddOrUpdate(new Subproject { Name = "First part", Description = "This is the first part", ProjectID = 1, Weight = 50 });
            context.Subprojects.AddOrUpdate( new Subproject { Name = "Second part", Description = "This is the second part", ProjectID = 2, Weight = 50 });

            context.Subprojects.AddOrUpdate(new Subproject { Name = "1st part", Description = "This is the first part", ProjectID = 1, Weight = 50 });
            context.Subprojects.AddOrUpdate(new Subproject { Name = "2nd part", Description = "This is the second part", ProjectID = 2, Weight = 50 });
            */
        }
    }
}
