namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAccountModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleType = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(maxLength: 20),
                        Address = c.String(maxLength: 255),
                        ProgramType = c.Int(nullable: false),
                        ProgramName = c.String(maxLength: 255),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        ICNumber = c.String(nullable: false, maxLength: 20),
                        Department = c.String(maxLength: 255),
                        AdminPosition = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAccounts");
        }
    }
}
