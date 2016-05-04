namespace Mooshark2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.CourseTeachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.InputOutputs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Input = c.String(),
                        Output = c.String(),
                        SubprojectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subprojects", t => t.SubprojectID, cascadeDelete: true)
                .Index(t => t.SubprojectID);
            
            CreateTable(
                "dbo.Subprojects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProjectID = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deadline = c.DateTime(nullable: false),
                        Graded = c.Boolean(nullable: false),
                        Visibility = c.Boolean(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.ProjectGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        SubprojectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subprojects", t => t.SubprojectID, cascadeDelete: true)
                .Index(t => t.SubprojectID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Submissions", "SubprojectID", "dbo.Subprojects");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectGroups", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectGroups", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.InputOutputs", "SubprojectID", "dbo.Subprojects");
            DropForeignKey("dbo.Subprojects", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Projects", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Groups", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseTeachers", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseTeachers", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseStudents", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseStudents", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Submissions", new[] { "SubprojectID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProjectGroups", new[] { "ProjectID" });
            DropIndex("dbo.ProjectGroups", new[] { "GroupID" });
            DropIndex("dbo.Projects", new[] { "CourseID" });
            DropIndex("dbo.Subprojects", new[] { "ProjectID" });
            DropIndex("dbo.InputOutputs", new[] { "SubprojectID" });
            DropIndex("dbo.Groups", new[] { "UserID" });
            DropIndex("dbo.CourseTeachers", new[] { "CourseID" });
            DropIndex("dbo.CourseTeachers", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CourseStudents", new[] { "CourseID" });
            DropIndex("dbo.CourseStudents", new[] { "UserID" });
            DropTable("dbo.Submissions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectGroups");
            DropTable("dbo.Projects");
            DropTable("dbo.Subprojects");
            DropTable("dbo.InputOutputs");
            DropTable("dbo.Groups");
            DropTable("dbo.CourseTeachers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Courses");
        }
    }
}
