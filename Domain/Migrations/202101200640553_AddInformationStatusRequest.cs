namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInformationStatusRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InformationStatusRequestLifeCycles",
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
                .ForeignKey("dbo.InformationStatusRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.InformationStatusRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false),
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
                .ForeignKey("dbo.Employees", t => t.ClientId)
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
                "dbo.InformationStatusRequestTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InformationStatusRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InformationStatusRequestLifeCycles", "RequestId", "dbo.InformationStatusRequests");
            DropForeignKey("dbo.InformationStatusRequestTitles", "RequestId", "dbo.InformationStatusRequests");
            DropForeignKey("dbo.InformationStatusRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.InformationStatusRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.InformationStatusRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.InformationStatusRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.InformationStatusRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.InformationStatusRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.InformationStatusRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.InformationStatusRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.InformationStatusRequestTitles", new[] { "RequestId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "ExecutorId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "ClientId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "PriorityId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "StatusId" });
            DropIndex("dbo.InformationStatusRequests", new[] { "ServiceId" });
            DropIndex("dbo.InformationStatusRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.InformationStatusRequestLifeCycles", new[] { "RequestId" });
            DropTable("dbo.InformationStatusRequestTitles");
            DropTable("dbo.InformationStatusRequests");
            DropTable("dbo.InformationStatusRequestLifeCycles");
        }
    }
}
