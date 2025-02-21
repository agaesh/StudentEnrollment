namespace StudentEnrollment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedDataTypeRoleTypeToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "RoleType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "RoleType", c => c.Int(nullable: false));
        }
    }
}
