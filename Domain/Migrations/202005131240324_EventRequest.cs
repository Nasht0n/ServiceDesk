namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TechnicalSupportEventEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        EquipmentName = c.String(nullable: false, maxLength: 150),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TechnicalSupportEventRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.TechnicalSupportEventRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(),
                        ExecutorGroupId = c.Int(nullable: false),
                        SubdivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ExecutorId)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Subdivisions", t => t.SubdivisionId, cascadeDelete: false)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId)
                .Index(t => t.SubdivisionId);
            
            CreateTable(
                "dbo.TechnicalSupportEventInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        CampusId = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 150),
                        EventDate = c.DateTime(nullable: false),
                        StartTime = c.String(nullable: false, maxLength: 100),
                        EndTime = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.TechnicalSupportEventRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.CampusId);
            
            CreateTable(
                "dbo.TechnicalSupportEventRequestLifeCycles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.TechnicalSupportEventRequests", t => t.RequestId, cascadeDelete: false)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnicalSupportEventRequestLifeCycles", "RequestId", "dbo.TechnicalSupportEventRequests");
            DropForeignKey("dbo.TechnicalSupportEventRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.TechnicalSupportEventInfos", "RequestId", "dbo.TechnicalSupportEventRequests");
            DropForeignKey("dbo.TechnicalSupportEventInfos", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.TechnicalSupportEventEquipments", "RequestId", "dbo.TechnicalSupportEventRequests");
            DropForeignKey("dbo.TechnicalSupportEventRequests", "ClientId", "dbo.Employees");
            DropIndex("dbo.TechnicalSupportEventRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.TechnicalSupportEventRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.TechnicalSupportEventInfos", new[] { "CampusId" });
            DropIndex("dbo.TechnicalSupportEventInfos", new[] { "RequestId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "ExecutorId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "ClientId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "PriorityId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "StatusId" });
            DropIndex("dbo.TechnicalSupportEventRequests", new[] { "ServiceId" });
            DropIndex("dbo.TechnicalSupportEventEquipments", new[] { "RequestId" });
            DropTable("dbo.TechnicalSupportEventRequestLifeCycles");
            DropTable("dbo.TechnicalSupportEventInfos");
            DropTable("dbo.TechnicalSupportEventRequests");
            DropTable("dbo.TechnicalSupportEventEquipments");
        }
    }
}
