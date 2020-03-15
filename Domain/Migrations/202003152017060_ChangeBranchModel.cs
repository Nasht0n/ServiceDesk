namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeBranchModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "Fullname", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Branches", "AreaName", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Branches", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Branches", "Name", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Branches", "AreaName");
            DropColumn("dbo.Branches", "Fullname");
        }
    }
}
