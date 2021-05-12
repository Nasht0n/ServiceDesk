namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEndDateTimeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VideoCommunicationRequests", "StartDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.VideoCommunicationRequests", "EndDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.VideoCommunicationRequests", "Date");
            DropColumn("dbo.VideoCommunicationRequests", "StartTime");
            DropColumn("dbo.VideoCommunicationRequests", "EndTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VideoCommunicationRequests", "EndTime", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.VideoCommunicationRequests", "StartTime", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.VideoCommunicationRequests", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.VideoCommunicationRequests", "EndDateTime");
            DropColumn("dbo.VideoCommunicationRequests", "StartDateTime");
        }
    }
}
