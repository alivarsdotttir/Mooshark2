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
            /*context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 2, UserID = "e4a87126-62a5-4904-8359-61d11732dd53" });
            context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 3, UserID = "e4a87126-62a5-4904-8359-61d11732dd53" });
            context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 4, UserID = "cd9fa9da-33d1-46a8-adb1-bb159f2d1563" });
            context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 5, UserID = "e72910df-2257-4810-925b-f9db055fbd61" });
            context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 6, UserID = "e72910df-2257-4810-925b-f9db055fbd61" });
            context.StudentSubmissions.AddOrUpdate(new StudentSubmission { SubmissionID = 7, UserID = "cd9fa9da-33d1-46a8-adb1-bb159f2d1563" });
            */
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = false, CppFileName = "HelloWorld.cpp", Grade = 0, SubprojectID = 1, FilePath = "C:/anna/lab3/sub1", SubmissionNr = 4, Output = "ekki rétt" });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = true, CppFileName = "HelloWorld.cpp", Grade = 10, SubprojectID = 1, FilePath = "C:/an/lab3/sub1", SubmissionNr = 1, Output = "rétt" });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = true, CppFileName = "HelloWorld.cpp", Grade = 10, SubprojectID = 1, FilePath = "C:/na/lab3/sub1", SubmissionNr = 2, Output = "rétt" });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = true, CppFileName = "HelloWorld.cpp", Grade = 10, SubprojectID = 1, FilePath = "C:/ana/lab3/sub1", SubmissionNr = 3, Output = " rétt" });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = false, CppFileName = "HelloWorld.cpp", Grade = 0, SubprojectID = 1, FilePath = "C:/aa/lab3/sub1", SubmissionNr = 1, Output = "ekki rétt" });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2015, 09, 08), Accepted = false, CppFileName = "HelloWorld.cpp", Grade = 0, SubprojectID = 1, FilePath = "C:/a/lab3/sub1", SubmissionNr = 1, Output = "ekki rétt" });

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

            context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = new DateTime(2017, 3, 9, 0, 0, 0), Graded = false, Visibility = true, CourseID = 1 });*/

            //context.Projects.AddOrUpdate(new Project { Name = "The Answer", Deadline = new DateTime(2017, 3, 9), Graded = false, Visibility = true, CourseID = 1, IsGroupProject = false, Grade = 0, GroupSize = 0 });
            //context.Projects.AddOrUpdate(new Project { CourseID = 1, Deadline = new DateTime(2016, 7, 5), IsGroupProject = false, Grade = 10, Graded = false, GroupSize = 1, Name = "TheAnswer", Visibility = true });

            //context.Projects.AddOrUpdate(new Project { Name = "Project 1", Deadline = new DateTime(2017, 3, 9, 0, 0, 0), Graded = false, Visibility = true, CourseID = 1 });

            //context.Projects.AddOrUpdate(new Project { Name = "The Answer", Deadline = new DateTime(2017, 3, 9), Graded = false, Visibility = true, CourseID = 1, IsGroupProject = false, Grade = 0, GroupSize = 0 });*/
            //context.Projects.AddOrUpdate(new Project { Name = "The Answer", Deadline = new DateTime(2017, 3, 9), Graded = false, Visibility = true, CourseID = 1, isGroupProject = false, Grade = 0, GroupSize = 0 });
            //context.Projects.AddOrUpdate(new Project { Name = "Project 3", GroupSize = 1, Grade = 10, IsGroupProject = false, CourseID = 11, Deadline = new DateTime(2016, 7, 6), Graded = false, Visibility = true });

            context.Subprojects.AddOrUpdate(new Subproject{ Name = "TheAnswer", Description = "Lorem Ipsum", Grade = 10, ProjectID = 10, Input = "2", Output ="The number you entered is 2", Weight = 100});

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

            //context.Subprojects.AddOrUpdate(new Subproject { Name = "The AnswerAnswer", Description = "This is the ANSWER", ProjectID = 8, Weight = 100 });
            /*
            context.Subprojects.AddOrUpdate( new Subproject { Name = "Second part", Description = "This is the second part", ProjectID = 2, Weight = 50 });
            
            context.Subprojects.AddOrUpdate(new Subproject { Name = "1st part", Description = "This is the first part", ProjectID = 1, Weight = 50 });
            context.Subprojects.AddOrUpdate(new Subproject { Name = "2nd part", Description = "This is the second part", ProjectID = 2, Weight = 50 });
            */

            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2016, 7, 7), Accepted = true, SubprojectID = 1, SubmissionNr = 1 });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2016, 6, 7), Accepted = false, SubprojectID = 1, SubmissionNr = 2 });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2016, 5, 7), Accepted = true, SubprojectID = 2, SubmissionNr = 1 });
            //context.Submissions.AddOrUpdate(new Submission { Date = new DateTime(2016, 5, 8), Accepted = true, SubprojectID = 2, SubmissionNr = 2 });

            //context.StudentSubmissions.AddOrUpdate(new StudentSubmission { UserID = "f9c37f8b-7133-4f32-ab2d-d85676d5eb90", SubmissionID = 1 });
            //context.StudentSubmissions.AddOrUpdate(new StudentSubmission { UserID = "f9c37f8b-7133-4f32-ab2d-d85676d5eb90", SubmissionID = 2 });
            //context.StudentSubmissions.AddOrUpdate(new StudentSubmission { UserID = "f9c37f8b-7133-4f32-ab2d-d85676d5eb90", SubmissionID = 3 });
            //context.StudentSubmissions.AddOrUpdate(new StudentSubmission { UserID = "f9c37f8b-7133-4f32-ab2d-d85676d5eb90", SubmissionID = 4 });
            //context.InputOutputs.AddOrUpdate(new InputOutput { Input = "2", Output = "2", SubprojectID = 6 });
        }
    }
}
