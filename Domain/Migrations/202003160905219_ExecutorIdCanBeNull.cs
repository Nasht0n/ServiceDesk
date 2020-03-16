namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExecutorIdCanBeNull : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AccountCancellationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ExecutorId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ExecutorId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ExecutorId" });
            AlterColumn("dbo.AccountCancellationRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.AccountDisconnectRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.AccountLossRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.AccountRegistrationRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.SoftwareDevelopmentRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.SoftwareReworkRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.ComponentReplaceRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EmailRegistrationRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EmailSizeIncreaseRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EquipmentInstallationRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EquipmentRefillRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EquipmentRepairRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.EquipmentReplaceRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.HoldingPhoneLineRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.NetworkConnectionRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.PhoneLineRepairRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.PhoneNumberAllocationRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.PhoneRepairRequests", "ExecutorId", c => c.Int());
            AlterColumn("dbo.VideoCommunicationRequests", "ExecutorId", c => c.Int());
            CreateIndex("dbo.AccountCancellationRequests", "ExecutorId");
            CreateIndex("dbo.AccountDisconnectRequests", "ExecutorId");
            CreateIndex("dbo.AccountLossRequests", "ExecutorId");
            CreateIndex("dbo.AccountRegistrationRequests", "ExecutorId");
            CreateIndex("dbo.SoftwareDevelopmentRequests", "ExecutorId");
            CreateIndex("dbo.SoftwareReworkRequests", "ExecutorId");
            CreateIndex("dbo.ComponentReplaceRequests", "ExecutorId");
            CreateIndex("dbo.EmailRegistrationRequests", "ExecutorId");
            CreateIndex("dbo.EmailSizeIncreaseRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentInstallationRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentRefillRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentRepairRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentReplaceRequests", "ExecutorId");
            CreateIndex("dbo.HoldingPhoneLineRequests", "ExecutorId");
            CreateIndex("dbo.NetworkConnectionRequests", "ExecutorId");
            CreateIndex("dbo.PhoneLineRepairRequests", "ExecutorId");
            CreateIndex("dbo.PhoneNumberAllocationRequests", "ExecutorId");
            CreateIndex("dbo.PhoneRepairRequests", "ExecutorId");
            CreateIndex("dbo.VideoCommunicationRequests", "ExecutorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.VideoCommunicationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "ExecutorId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "ExecutorId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "ExecutorId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountLossRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "ExecutorId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "ExecutorId" });
            AlterColumn("dbo.VideoCommunicationRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhoneRepairRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhoneNumberAllocationRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.PhoneLineRepairRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.NetworkConnectionRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.HoldingPhoneLineRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EquipmentReplaceRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EquipmentRepairRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EquipmentRefillRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EquipmentInstallationRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EmailSizeIncreaseRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.EmailRegistrationRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.ComponentReplaceRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.SoftwareReworkRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.SoftwareDevelopmentRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountRegistrationRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountLossRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountDisconnectRequests", "ExecutorId", c => c.Int(nullable: false));
            AlterColumn("dbo.AccountCancellationRequests", "ExecutorId", c => c.Int(nullable: false));
            CreateIndex("dbo.VideoCommunicationRequests", "ExecutorId");
            CreateIndex("dbo.PhoneRepairRequests", "ExecutorId");
            CreateIndex("dbo.PhoneNumberAllocationRequests", "ExecutorId");
            CreateIndex("dbo.PhoneLineRepairRequests", "ExecutorId");
            CreateIndex("dbo.NetworkConnectionRequests", "ExecutorId");
            CreateIndex("dbo.HoldingPhoneLineRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentReplaceRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentRepairRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentRefillRequests", "ExecutorId");
            CreateIndex("dbo.EquipmentInstallationRequests", "ExecutorId");
            CreateIndex("dbo.EmailSizeIncreaseRequests", "ExecutorId");
            CreateIndex("dbo.EmailRegistrationRequests", "ExecutorId");
            CreateIndex("dbo.ComponentReplaceRequests", "ExecutorId");
            CreateIndex("dbo.SoftwareReworkRequests", "ExecutorId");
            CreateIndex("dbo.SoftwareDevelopmentRequests", "ExecutorId");
            CreateIndex("dbo.AccountRegistrationRequests", "ExecutorId");
            CreateIndex("dbo.AccountLossRequests", "ExecutorId");
            CreateIndex("dbo.AccountDisconnectRequests", "ExecutorId");
            CreateIndex("dbo.AccountCancellationRequests", "ExecutorId");
        }
    }
}
