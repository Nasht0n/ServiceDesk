namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndTimeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoCommunicationRequests", "StartTime", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.VideoCommunicationRequests", "EndTime", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.VideoCommunicationRequests", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoCommunicationRequests", "Time", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.VideoCommunicationRequests", "EndTime");
            DropColumn("dbo.VideoCommunicationRequests", "StartTime");
        }
    }
}
