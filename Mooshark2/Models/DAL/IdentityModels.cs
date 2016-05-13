using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooshark2.Models.Entities;

namespace Mooshark2.Models.DAL
{
    /// <summary>
    /// The class ApplicationUser contains information concerning the user 
    /// It inherits from the class IdentityUser
    /// </summary>
   
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string SSN { get; set; }
        public string FullName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudent> CourseStudents { get; set; }
        public DbSet<CourseTeacher> CourseTeachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<InputOutput> InputOutputs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectGroup> ProjectGroups { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Subproject> Subprojects { get; set; }
        public DbSet<ProjectSubproject> ProjectSubprojects { get; set; }
        public DbSet<StudentSubmission> StudentSubmissions { get; set; }
        public DbSet<CourseProject> CourseProjects { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}