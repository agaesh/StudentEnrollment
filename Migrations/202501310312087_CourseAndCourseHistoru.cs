namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAndCourseHistoru : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        Credits = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.CourseHistories",
                c => new
                    {
                        CourseCode = c.String(nullable: false),
                        CourseName = c.String(),
                        Description = c.String(),
                        ID = c.Int(nullable: false, identity: true),
                        Action = c.String(nullable: false, maxLength: 100),
                        ActionDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseHistories");
            DropTable("dbo.Courses");
        }
    }
}
