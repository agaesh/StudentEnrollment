namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBankingDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "BankName", c => c.String());
            AddColumn("dbo.UserAccounts", "AccountNo", c => c.String());
            AddColumn("dbo.UserAccounts", "AccountType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "AccountType");
            DropColumn("dbo.UserAccounts", "AccountNo");
            DropColumn("dbo.UserAccounts", "BankName");
        }
    }
}
