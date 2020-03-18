namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAccountModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Username", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Accounts", "Password", c => c.String(nullable: false, maxLength: 25));
            DropColumn("dbo.Permissions", "Value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "Value", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Accounts", "Password", c => c.String());
            AlterColumn("dbo.Accounts", "Username", c => c.String());
        }
    }
}
