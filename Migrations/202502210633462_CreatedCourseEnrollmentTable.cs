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
                        CourseId = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        CompletionDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.CourseEnrollments", "StudentId", "dbo.UserAccounts");
            DropForeignKey("dbo.CourseEnrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseEnrollments", new[] { "CourseId" });
            DropIndex("dbo.CourseEnrollments", new[] { "StudentId" });
            DropTable("dbo.CourseEnrollments");
        }
    }
}
