namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUpdateDateTitleInfoStatusRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InformationStatusRequestTitles", "UpdateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InformationStatusRequestTitles", "UpdateDate");
        }
    }
}
