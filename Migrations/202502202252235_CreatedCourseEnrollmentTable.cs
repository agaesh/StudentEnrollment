namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCourseEnrollmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseEnrollments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    StudentId = c.Int(nullable: false),
                    ProgramType = c.String(nullable: true),
                    ProgramName = c.String(nullable: true),
                    EnrollmentDate = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Status = c.Int(nullable: false),
                    PaymentStatus = c.Int(nullable: false),
                    CompletionDate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.StudentId, cascadeDelete: true)
                //.ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.StudentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.CourseEnrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseEnrollments", "StudentId", "dbo.Students");
            DropIndex("dbo.CourseEnrollments", new[] { "StudentId" });
            DropTable("dbo.CourseEnrollments");
        }
    }
}
