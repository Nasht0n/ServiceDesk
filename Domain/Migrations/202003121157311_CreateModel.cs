namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountCancellationRequestLifeCycles",
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
                .ForeignKey("dbo.AccountCancellationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 150),
                        Firstname = c.String(nullable: false, maxLength: 100),
                        Patronymic = c.String(nullable: false, maxLength: 150),
                        Post = c.String(nullable: false, maxLength: 100),
                        Email = c.String(maxLength: 150),
                        Phone = c.String(maxLength: 25),
                        HeadOfUnit = c.Boolean(nullable: false),
                        SubdivisionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subdivisions", t => t.SubdivisionId, cascadeDelete: true)
                .Index(t => t.SubdivisionId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Visible = c.Boolean(nullable: false),
                        ApprovalRequired = c.Boolean(nullable: false),
                        Controller = c.String(nullable: false, maxLength: 150),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExecutorGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cabinets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subdivisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 200),
                        Shortname = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountCancellationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Filename = c.String(nullable: false, maxLength: 150),
                        DateUploaded = c.DateTime(nullable: false),
                        Path = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountDisconnectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.Priorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        Shortname = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 150),
                        Shortname = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountLossRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.AccountRegistrationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.SoftwareDevelopmentRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.SoftwareReworkRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.AccountDisconnectRequestLifeCycles",
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
                .ForeignKey("dbo.AccountDisconnectRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AccountLossRequestLifeCycles",
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
                .ForeignKey("dbo.AccountLossRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AccountRegistrationRequestLifeCycles",
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
                .ForeignKey("dbo.AccountRegistrationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        DateRegistration = c.DateTime(nullable: false),
                        DateChangePassword = c.DateTime(nullable: false),
                        LastEnterDateTime = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        ChangePasswordOnNextEnter = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Value = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ComponentReplaceRequestLifeCycles",
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
                .ForeignKey("dbo.ComponentReplaceRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.ComponentReplaceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.ReplaceComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        ComponentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Components", t => t.ComponentId, cascadeDelete: true)
                .ForeignKey("dbo.ComponentReplaceRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.ComponentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConnectionEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        NetworkConnectionRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.NetworkConnectionRequests", t => t.NetworkConnectionRequest_Id)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.NetworkConnectionRequest_Id);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmailRegistrationRequestLifeCycles",
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
                .ForeignKey("dbo.EmailRegistrationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmailRegistrationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.EmailSizeIncreaseRequestLifeCycles",
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
                .ForeignKey("dbo.EmailSizeIncreaseRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmailSizeIncreaseRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.EquipmentInstallationRequestLifeCycles",
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
                .ForeignKey("dbo.EquipmentInstallationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EquipmentInstallationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.InstallationEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentInstallationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.EquipmentRefillRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.RefillEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventoryNumber = c.String(),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentRefillRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.EquipmentRefillRequestLifeCycles",
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
                .ForeignKey("dbo.EquipmentRefillRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EquipmentRepairRequestLifeCycles",
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
                .ForeignKey("dbo.EquipmentRepairRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EquipmentRepairRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        InventoryNumber = c.String(nullable: false),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.RepairEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                        ConsumableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumables", t => t.ConsumableId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentRepairRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.ConsumableId);
            
            CreateTable(
                "dbo.Consumables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentReplaceRequestLifeCycles",
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
                .ForeignKey("dbo.EquipmentReplaceRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EquipmentReplaceRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.ReplaceEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventoryNumber = c.String(),
                        RequestId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentReplaceRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        InventoryNumber = c.String(nullable: false, maxLength: 100),
                        EquipmentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.HoldingPhoneLineRequestLifeCycles",
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
                .ForeignKey("dbo.HoldingPhoneLineRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.HoldingPhoneLineRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.NetworkConnectionRequestLifeCycles",
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
                .ForeignKey("dbo.NetworkConnectionRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.NetworkConnectionRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Shortname = c.String(nullable: false, maxLength: 20),
                        Logo = c.Binary(),
                        Address = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhoneLineRepairRequestLifeCycles",
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
                .ForeignKey("dbo.PhoneLineRepairRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PhoneLineRepairRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.PhoneNumberAllocationRequestLifeCycles",
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
                .ForeignKey("dbo.PhoneNumberAllocationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PhoneNumberAllocationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.PhoneRepairRequestLifeCycles",
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
                .ForeignKey("dbo.PhoneRepairRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.PhoneRepairRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.RefuelingLimits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        SubdvisionId = c.Int(nullable: false),
                        Subdivision_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subdivisions", t => t.Subdivision_Id)
                .Index(t => t.Subdivision_Id);
            
            CreateTable(
                "dbo.SoftwareDevelopmentRequestLifeCycles",
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
                .ForeignKey("dbo.SoftwareDevelopmentRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.SoftwareReworkRequestLifeCycles",
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
                .ForeignKey("dbo.SoftwareReworkRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.VideoCommunicationRequestLifeCycles",
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
                .ForeignKey("dbo.VideoCommunicationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.VideoCommunicationRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false, maxLength: 150),
                        Date = c.DateTime(nullable: false),
                        CampusId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Justification = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false, maxLength: 255),
                        ServiceId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        PriorityId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        ExecutorId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ClientId, cascadeDelete: false)
                .ForeignKey("dbo.Employees", t => t.ExecutorId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.ExecutorGroupId, cascadeDelete: true)
                .ForeignKey("dbo.Priorities", t => t.PriorityId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CampusId)
                .Index(t => t.ServiceId)
                .Index(t => t.StatusId)
                .Index(t => t.PriorityId)
                .Index(t => t.ClientId)
                .Index(t => t.ExecutorId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.ServicesExecutorGroups",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        ExecutorGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.ExecutorGroupId })
                .ForeignKey("dbo.ExecutorGroups", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ExecutorGroupId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.ExecutorGroupId);
            
            CreateTable(
                "dbo.ServicesApprovers",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.EmployeeId })
                .ForeignKey("dbo.Employees", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.CabinetEmployees",
                c => new
                    {
                        Cabinet_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cabinet_Id, t.Employee_Id })
                .ForeignKey("dbo.Cabinets", t => t.Cabinet_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Cabinet_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.ExecutorGroupMembers",
                c => new
                    {
                        ExecutorGroupId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ExecutorGroupId, t.EmployeeId })
                .ForeignKey("dbo.Employees", t => t.ExecutorGroupId, cascadeDelete: false)
                .ForeignKey("dbo.ExecutorGroups", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.ExecutorGroupId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.SubdivisionExecutors",
                c => new
                    {
                        SubdivisionId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubdivisionId, t.EmployeeId })
                .ForeignKey("dbo.Employees", t => t.SubdivisionId, cascadeDelete: false)
                .ForeignKey("dbo.Subdivisions", t => t.EmployeeId, cascadeDelete: false)
                .Index(t => t.SubdivisionId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AccountCancellationRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.AccountCancellationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.AccountDisconnectRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.AccountDisconnectRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.AccountLossRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.AccountLossRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.AccountRegistrationRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.AccountRegistrationRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.SoftwareDevelopmentRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.SoftwareDevelopmentRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.SoftwareReworkRequestAttachments",
                c => new
                    {
                        AttachmentId = c.Int(nullable: false),
                        RequestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttachmentId, t.RequestId })
                .ForeignKey("dbo.Attachments", t => t.AttachmentId, cascadeDelete: true)
                .ForeignKey("dbo.SoftwareReworkRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.AttachmentId)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.AccountsPermissions",
                c => new
                    {
                        AccountId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AccountId, t.PermissionId })
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: false)
                .ForeignKey("dbo.Permissions", t => t.PermissionId, cascadeDelete: false)
                .Index(t => t.AccountId)
                .Index(t => t.PermissionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoCommunicationRequestLifeCycles", "RequestId", "dbo.VideoCommunicationRequests");
            DropForeignKey("dbo.VideoCommunicationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.VideoCommunicationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.VideoCommunicationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.VideoCommunicationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.VideoCommunicationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.VideoCommunicationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.VideoCommunicationRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.VideoCommunicationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareReworkRequestLifeCycles", "RequestId", "dbo.SoftwareReworkRequests");
            DropForeignKey("dbo.SoftwareReworkRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareDevelopmentRequestLifeCycles", "RequestId", "dbo.SoftwareDevelopmentRequests");
            DropForeignKey("dbo.SoftwareDevelopmentRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.RefuelingLimits", "Subdivision_Id", "dbo.Subdivisions");
            DropForeignKey("dbo.PhoneRepairRequestLifeCycles", "RequestId", "dbo.PhoneRepairRequests");
            DropForeignKey("dbo.PhoneRepairRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.PhoneRepairRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PhoneRepairRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.PhoneRepairRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.PhoneRepairRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.PhoneRepairRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.PhoneRepairRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.PhoneRepairRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PhoneNumberAllocationRequestLifeCycles", "RequestId", "dbo.PhoneNumberAllocationRequests");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.PhoneNumberAllocationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.PhoneLineRepairRequestLifeCycles", "RequestId", "dbo.PhoneLineRepairRequests");
            DropForeignKey("dbo.PhoneLineRepairRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.PhoneLineRepairRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.PhoneLineRepairRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.PhoneLineRepairRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.PhoneLineRepairRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.PhoneLineRepairRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.PhoneLineRepairRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.PhoneLineRepairRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.NetworkConnectionRequestLifeCycles", "RequestId", "dbo.NetworkConnectionRequests");
            DropForeignKey("dbo.NetworkConnectionRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.NetworkConnectionRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.NetworkConnectionRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.NetworkConnectionRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.NetworkConnectionRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.ConnectionEquipments", "NetworkConnectionRequest_Id", "dbo.NetworkConnectionRequests");
            DropForeignKey("dbo.NetworkConnectionRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.NetworkConnectionRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.NetworkConnectionRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.HoldingPhoneLineRequestLifeCycles", "RequestId", "dbo.HoldingPhoneLineRequests");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.HoldingPhoneLineRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.EquipmentReplaceRequestLifeCycles", "RequestId", "dbo.EquipmentReplaceRequests");
            DropForeignKey("dbo.EquipmentReplaceRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EquipmentReplaceRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ReplaceEquipments", "RequestId", "dbo.EquipmentReplaceRequests");
            DropForeignKey("dbo.ReplaceEquipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.EquipmentReplaceRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.EquipmentReplaceRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EquipmentReplaceRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentReplaceRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentReplaceRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.EquipmentReplaceRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRepairRequestLifeCycles", "RequestId", "dbo.EquipmentRepairRequests");
            DropForeignKey("dbo.EquipmentRepairRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EquipmentRepairRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RepairEquipments", "RequestId", "dbo.EquipmentRepairRequests");
            DropForeignKey("dbo.RepairEquipments", "ConsumableId", "dbo.Consumables");
            DropForeignKey("dbo.EquipmentRepairRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.EquipmentRepairRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EquipmentRepairRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRepairRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRepairRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.EquipmentRepairRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRefillRequestLifeCycles", "RequestId", "dbo.EquipmentRefillRequests");
            DropForeignKey("dbo.EquipmentRefillRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRefillRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EquipmentRefillRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.RefillEquipments", "RequestId", "dbo.EquipmentRefillRequests");
            DropForeignKey("dbo.EquipmentRefillRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.EquipmentRefillRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EquipmentRefillRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRefillRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentRefillRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.EquipmentInstallationRequestLifeCycles", "RequestId", "dbo.EquipmentInstallationRequests");
            DropForeignKey("dbo.EquipmentInstallationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EquipmentInstallationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EquipmentInstallationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.InstallationEquipments", "RequestId", "dbo.EquipmentInstallationRequests");
            DropForeignKey("dbo.InstallationEquipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.EquipmentInstallationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EquipmentInstallationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentInstallationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EquipmentInstallationRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.EquipmentInstallationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmailSizeIncreaseRequestLifeCycles", "RequestId", "dbo.EmailSizeIncreaseRequests");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EmailSizeIncreaseRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmailRegistrationRequestLifeCycles", "RequestId", "dbo.EmailRegistrationRequests");
            DropForeignKey("dbo.EmailRegistrationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EmailRegistrationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.EmailRegistrationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.EmailRegistrationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.EmailRegistrationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.EmailRegistrationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.EmailRegistrationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ConnectionEquipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.ComponentReplaceRequestLifeCycles", "RequestId", "dbo.ComponentReplaceRequests");
            DropForeignKey("dbo.ComponentReplaceRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.ComponentReplaceRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ReplaceComponents", "RequestId", "dbo.ComponentReplaceRequests");
            DropForeignKey("dbo.ReplaceComponents", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.ComponentReplaceRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.ComponentReplaceRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.ComponentReplaceRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.ComponentReplaceRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.ComponentReplaceRequests", "CampusId", "dbo.Campus");
            DropForeignKey("dbo.ComponentReplaceRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AccountsPermissions", "PermissionId", "dbo.Permissions");
            DropForeignKey("dbo.AccountsPermissions", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AccountRegistrationRequestLifeCycles", "RequestId", "dbo.AccountRegistrationRequests");
            DropForeignKey("dbo.AccountRegistrationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AccountLossRequestLifeCycles", "RequestId", "dbo.AccountLossRequests");
            DropForeignKey("dbo.AccountLossRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AccountDisconnectRequestLifeCycles", "RequestId", "dbo.AccountDisconnectRequests");
            DropForeignKey("dbo.AccountDisconnectRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AccountCancellationRequestLifeCycles", "RequestId", "dbo.AccountCancellationRequests");
            DropForeignKey("dbo.AccountCancellationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AccountCancellationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.AccountCancellationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.AccountCancellationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.AccountCancellationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.AccountCancellationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareReworkRequestAttachments", "RequestId", "dbo.SoftwareReworkRequests");
            DropForeignKey("dbo.SoftwareReworkRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.SoftwareReworkRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SoftwareReworkRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.SoftwareReworkRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.SoftwareReworkRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.SoftwareReworkRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareReworkRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareDevelopmentRequestAttachments", "RequestId", "dbo.SoftwareDevelopmentRequests");
            DropForeignKey("dbo.SoftwareDevelopmentRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.AccountRegistrationRequestAttachments", "RequestId", "dbo.AccountRegistrationRequests");
            DropForeignKey("dbo.AccountRegistrationRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.AccountRegistrationRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AccountRegistrationRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.AccountRegistrationRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.AccountRegistrationRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.AccountRegistrationRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.AccountRegistrationRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.AccountLossRequestAttachments", "RequestId", "dbo.AccountLossRequests");
            DropForeignKey("dbo.AccountLossRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.AccountLossRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AccountLossRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.AccountLossRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.AccountLossRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.AccountLossRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.AccountLossRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.AccountDisconnectRequestAttachments", "RequestId", "dbo.AccountDisconnectRequests");
            DropForeignKey("dbo.AccountDisconnectRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.AccountDisconnectRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.AccountDisconnectRequests", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.AccountDisconnectRequests", "PriorityId", "dbo.Priorities");
            DropForeignKey("dbo.AccountDisconnectRequests", "ExecutorGroupId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.AccountDisconnectRequests", "ExecutorId", "dbo.Employees");
            DropForeignKey("dbo.AccountDisconnectRequests", "ClientId", "dbo.Employees");
            DropForeignKey("dbo.AccountCancellationRequestAttachments", "RequestId", "dbo.AccountCancellationRequests");
            DropForeignKey("dbo.AccountCancellationRequestAttachments", "AttachmentId", "dbo.Attachments");
            DropForeignKey("dbo.AccountCancellationRequestLifeCycles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.SubdivisionExecutors", "EmployeeId", "dbo.Subdivisions");
            DropForeignKey("dbo.SubdivisionExecutors", "SubdivisionId", "dbo.Employees");
            DropForeignKey("dbo.ExecutorGroupMembers", "EmployeeId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.ExecutorGroupMembers", "ExecutorGroupId", "dbo.Employees");
            DropForeignKey("dbo.CabinetEmployees", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CabinetEmployees", "Cabinet_Id", "dbo.Cabinets");
            DropForeignKey("dbo.ServicesApprovers", "EmployeeId", "dbo.Services");
            DropForeignKey("dbo.ServicesApprovers", "ServiceId", "dbo.Employees");
            DropForeignKey("dbo.ServicesExecutorGroups", "ExecutorGroupId", "dbo.Services");
            DropForeignKey("dbo.ServicesExecutorGroups", "ServiceId", "dbo.ExecutorGroups");
            DropForeignKey("dbo.Services", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "BranchId", "dbo.Branches");
            DropIndex("dbo.AccountsPermissions", new[] { "PermissionId" });
            DropIndex("dbo.AccountsPermissions", new[] { "AccountId" });
            DropIndex("dbo.SoftwareReworkRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.SoftwareReworkRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.SoftwareDevelopmentRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.SoftwareDevelopmentRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.AccountRegistrationRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.AccountRegistrationRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.AccountLossRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.AccountLossRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.AccountDisconnectRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.AccountDisconnectRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.AccountCancellationRequestAttachments", new[] { "RequestId" });
            DropIndex("dbo.AccountCancellationRequestAttachments", new[] { "AttachmentId" });
            DropIndex("dbo.SubdivisionExecutors", new[] { "EmployeeId" });
            DropIndex("dbo.SubdivisionExecutors", new[] { "SubdivisionId" });
            DropIndex("dbo.ExecutorGroupMembers", new[] { "EmployeeId" });
            DropIndex("dbo.ExecutorGroupMembers", new[] { "ExecutorGroupId" });
            DropIndex("dbo.CabinetEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.CabinetEmployees", new[] { "Cabinet_Id" });
            DropIndex("dbo.ServicesApprovers", new[] { "EmployeeId" });
            DropIndex("dbo.ServicesApprovers", new[] { "ServiceId" });
            DropIndex("dbo.ServicesExecutorGroups", new[] { "ExecutorGroupId" });
            DropIndex("dbo.ServicesExecutorGroups", new[] { "ServiceId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ClientId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "PriorityId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "StatusId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ServiceId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "CampusId" });
            DropIndex("dbo.VideoCommunicationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.VideoCommunicationRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.SoftwareReworkRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.SoftwareReworkRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.SoftwareDevelopmentRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.SoftwareDevelopmentRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.RefuelingLimits", new[] { "Subdivision_Id" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ClientId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "PriorityId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "StatusId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ServiceId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "CampusId" });
            DropIndex("dbo.PhoneRepairRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.PhoneRepairRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ClientId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "PriorityId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "StatusId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ServiceId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "CampusId" });
            DropIndex("dbo.PhoneNumberAllocationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.PhoneNumberAllocationRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ClientId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "PriorityId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "StatusId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ServiceId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "CampusId" });
            DropIndex("dbo.PhoneLineRepairRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.PhoneLineRepairRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ExecutorId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ClientId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "PriorityId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "StatusId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ServiceId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "CampusId" });
            DropIndex("dbo.NetworkConnectionRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.NetworkConnectionRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ExecutorId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ClientId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "PriorityId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "StatusId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ServiceId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "CampusId" });
            DropIndex("dbo.HoldingPhoneLineRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.HoldingPhoneLineRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentTypeId" });
            DropIndex("dbo.ReplaceEquipments", new[] { "EquipmentTypeId" });
            DropIndex("dbo.ReplaceEquipments", new[] { "RequestId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ClientId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "PriorityId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "StatusId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ServiceId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "CampusId" });
            DropIndex("dbo.EquipmentReplaceRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EquipmentReplaceRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.RepairEquipments", new[] { "ConsumableId" });
            DropIndex("dbo.RepairEquipments", new[] { "RequestId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ClientId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "PriorityId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "StatusId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ServiceId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "CampusId" });
            DropIndex("dbo.EquipmentRepairRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EquipmentRepairRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.EquipmentRefillRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EquipmentRefillRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.RefillEquipments", new[] { "RequestId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ClientId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "PriorityId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "StatusId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ServiceId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "CampusId" });
            DropIndex("dbo.InstallationEquipments", new[] { "EquipmentTypeId" });
            DropIndex("dbo.InstallationEquipments", new[] { "RequestId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ClientId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "PriorityId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "StatusId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ServiceId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "CampusId" });
            DropIndex("dbo.EquipmentInstallationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EquipmentInstallationRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ClientId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "PriorityId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "StatusId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ServiceId" });
            DropIndex("dbo.EmailSizeIncreaseRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EmailSizeIncreaseRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ClientId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "PriorityId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "StatusId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ServiceId" });
            DropIndex("dbo.EmailRegistrationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.EmailRegistrationRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.ConnectionEquipments", new[] { "NetworkConnectionRequest_Id" });
            DropIndex("dbo.ConnectionEquipments", new[] { "EquipmentTypeId" });
            DropIndex("dbo.ReplaceComponents", new[] { "RequestId" });
            DropIndex("dbo.ReplaceComponents", new[] { "ComponentId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ClientId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "PriorityId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "StatusId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ServiceId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "CampusId" });
            DropIndex("dbo.ComponentReplaceRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.ComponentReplaceRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.Accounts", new[] { "EmployeeId" });
            DropIndex("dbo.AccountRegistrationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.AccountRegistrationRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.AccountLossRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.AccountLossRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.AccountDisconnectRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.AccountDisconnectRequestLifeCycles", new[] { "RequestId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ClientId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "PriorityId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "StatusId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ServiceId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ClientId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "PriorityId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "StatusId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ServiceId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ClientId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "PriorityId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "StatusId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ServiceId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ClientId" });
            DropIndex("dbo.AccountLossRequests", new[] { "PriorityId" });
            DropIndex("dbo.AccountLossRequests", new[] { "StatusId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ServiceId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ClientId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "PriorityId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "StatusId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ServiceId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "ExecutorGroupId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "ClientId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "PriorityId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "StatusId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "ServiceId" });
            DropIndex("dbo.Categories", new[] { "BranchId" });
            DropIndex("dbo.Services", new[] { "CategoryId" });
            DropIndex("dbo.Employees", new[] { "SubdivisionId" });
            DropIndex("dbo.AccountCancellationRequestLifeCycles", new[] { "EmployeeId" });
            DropIndex("dbo.AccountCancellationRequestLifeCycles", new[] { "RequestId" });
            DropTable("dbo.AccountsPermissions");
            DropTable("dbo.SoftwareReworkRequestAttachments");
            DropTable("dbo.SoftwareDevelopmentRequestAttachments");
            DropTable("dbo.AccountRegistrationRequestAttachments");
            DropTable("dbo.AccountLossRequestAttachments");
            DropTable("dbo.AccountDisconnectRequestAttachments");
            DropTable("dbo.AccountCancellationRequestAttachments");
            DropTable("dbo.SubdivisionExecutors");
            DropTable("dbo.ExecutorGroupMembers");
            DropTable("dbo.CabinetEmployees");
            DropTable("dbo.ServicesApprovers");
            DropTable("dbo.ServicesExecutorGroups");
            DropTable("dbo.VideoCommunicationRequests");
            DropTable("dbo.VideoCommunicationRequestLifeCycles");
            DropTable("dbo.SoftwareReworkRequestLifeCycles");
            DropTable("dbo.SoftwareDevelopmentRequestLifeCycles");
            DropTable("dbo.RefuelingLimits");
            DropTable("dbo.PhoneRepairRequests");
            DropTable("dbo.PhoneRepairRequestLifeCycles");
            DropTable("dbo.PhoneNumberAllocationRequests");
            DropTable("dbo.PhoneNumberAllocationRequestLifeCycles");
            DropTable("dbo.PhoneLineRepairRequests");
            DropTable("dbo.PhoneLineRepairRequestLifeCycles");
            DropTable("dbo.Organizations");
            DropTable("dbo.NetworkConnectionRequests");
            DropTable("dbo.NetworkConnectionRequestLifeCycles");
            DropTable("dbo.HoldingPhoneLineRequests");
            DropTable("dbo.HoldingPhoneLineRequestLifeCycles");
            DropTable("dbo.Equipments");
            DropTable("dbo.ReplaceEquipments");
            DropTable("dbo.EquipmentReplaceRequests");
            DropTable("dbo.EquipmentReplaceRequestLifeCycles");
            DropTable("dbo.Consumables");
            DropTable("dbo.RepairEquipments");
            DropTable("dbo.EquipmentRepairRequests");
            DropTable("dbo.EquipmentRepairRequestLifeCycles");
            DropTable("dbo.EquipmentRefillRequestLifeCycles");
            DropTable("dbo.RefillEquipments");
            DropTable("dbo.EquipmentRefillRequests");
            DropTable("dbo.InstallationEquipments");
            DropTable("dbo.EquipmentInstallationRequests");
            DropTable("dbo.EquipmentInstallationRequestLifeCycles");
            DropTable("dbo.EmailSizeIncreaseRequests");
            DropTable("dbo.EmailSizeIncreaseRequestLifeCycles");
            DropTable("dbo.EmailRegistrationRequests");
            DropTable("dbo.EmailRegistrationRequestLifeCycles");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.ConnectionEquipments");
            DropTable("dbo.Components");
            DropTable("dbo.ReplaceComponents");
            DropTable("dbo.ComponentReplaceRequests");
            DropTable("dbo.ComponentReplaceRequestLifeCycles");
            DropTable("dbo.Campus");
            DropTable("dbo.Permissions");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountRegistrationRequestLifeCycles");
            DropTable("dbo.AccountLossRequestLifeCycles");
            DropTable("dbo.AccountDisconnectRequestLifeCycles");
            DropTable("dbo.SoftwareReworkRequests");
            DropTable("dbo.SoftwareDevelopmentRequests");
            DropTable("dbo.AccountRegistrationRequests");
            DropTable("dbo.AccountLossRequests");
            DropTable("dbo.Status");
            DropTable("dbo.Priorities");
            DropTable("dbo.AccountDisconnectRequests");
            DropTable("dbo.Attachments");
            DropTable("dbo.AccountCancellationRequests");
            DropTable("dbo.Subdivisions");
            DropTable("dbo.Cabinets");
            DropTable("dbo.ExecutorGroups");
            DropTable("dbo.Branches");
            DropTable("dbo.Categories");
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.AccountCancellationRequestLifeCycles");
        }
    }
}
