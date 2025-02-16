namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountUnnecessaryColumnDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
