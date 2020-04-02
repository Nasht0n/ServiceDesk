namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldsAccountAndService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ManyApprovalRequired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "ManyApprovalRequired");
        }
    }
}
