namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeFieldToVideoRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoCommunicationRequests", "Time", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoCommunicationRequests", "Time");
        }
    }
}
