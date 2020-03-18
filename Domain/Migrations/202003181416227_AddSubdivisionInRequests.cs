namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSubdivisionInRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountCancellationRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountDisconnectRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountLossRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.AccountRegistrationRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.SoftwareDevelopmentRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.SoftwareReworkRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.Permissions", "Name", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.ComponentReplaceRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EmailRegistrationRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EmailSizeIncreaseRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EquipmentInstallationRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EquipmentRefillRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EquipmentRepairRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.EquipmentReplaceRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.HoldingPhoneLineRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.NetworkConnectionRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneLineRepairRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneNumberAllocationRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.PhoneRepairRequests", "SubdivisionId", c => c.Int(nullable: false));
            AddColumn("dbo.VideoCommunicationRequests", "SubdivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.AccountCancellationRequests", "SubdivisionId");
            CreateIndex("dbo.AccountDisconnectRequests", "SubdivisionId");
            CreateIndex("dbo.AccountLossRequests", "SubdivisionId");
            CreateIndex("dbo.AccountRegistrationRequests", "SubdivisionId");
            CreateIndex("dbo.SoftwareDevelopmentRequests", "SubdivisionId");
            CreateIndex("dbo.SoftwareReworkRequests", "SubdivisionId");
            CreateIndex("dbo.ComponentReplaceRequests", "SubdivisionId");
            CreateIndex("dbo.EmailRegistrationRequests", "SubdivisionId");
            CreateIndex("dbo.EmailSizeIncreaseRequests", "SubdivisionId");
            CreateIndex("dbo.EquipmentInstallationRequests", "SubdivisionId");
            CreateIndex("dbo.EquipmentRefillRequests", "SubdivisionId");
            CreateIndex("dbo.EquipmentRepairRequests", "SubdivisionId");
            CreateIndex("dbo.EquipmentReplaceRequests", "SubdivisionId");
            CreateIndex("dbo.HoldingPhoneLineRequests", "SubdivisionId");
            CreateIndex("dbo.NetworkConnectionRequests", "SubdivisionId");
            CreateIndex("dbo.PhoneLineRepairRequests", "SubdivisionId");
            CreateIndex("dbo.PhoneNumberAllocationRequests", "SubdivisionId");
            CreateIndex("dbo.PhoneRepairRequests", "SubdivisionId");
            CreateIndex("dbo.VideoCommunicationRequests", "SubdivisionId");
            AddForeignKey("dbo.AccountDisconnectRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AccountLossRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AccountRegistrationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.SoftwareDevelopmentRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.SoftwareReworkRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AccountCancellationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ComponentReplaceRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EmailRegistrationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EmailSizeIncreaseRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EquipmentInstallationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EquipmentRefillRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EquipmentRepairRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.EquipmentReplaceRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.HoldingPhoneLineRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NetworkConnectionRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PhoneLineRepairRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PhoneNumberAllocationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PhoneRepairRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VideoCommunicationRequests", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoCommunicationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.PhoneRepairRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.PhoneNumberAllocationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.PhoneLineRepairRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.NetworkConnectionRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.HoldingPhoneLineRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EquipmentReplaceRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EquipmentRepairRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EquipmentRefillRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EquipmentInstallationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EmailSizeIncreaseRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.EmailRegistrationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.ComponentReplaceRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.AccountCancellationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.SoftwareReworkRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.SoftwareDevelopmentRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.AccountRegistrationRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.AccountLossRequests", "SubdivisionId", "dbo.Subdivisions");
            DropForeignKey("dbo.AccountDisconnectRequests", "SubdivisionId", "dbo.Subdivisions");
            DropIndex("dbo.VideoCommunicationRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.PhoneRepairRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.PhoneNumberAllocationRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.PhoneLineRepairRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.NetworkConnectionRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.HoldingPhoneLineRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EquipmentReplaceRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EquipmentRepairRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EquipmentRefillRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EquipmentInstallationRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EmailSizeIncreaseRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.EmailRegistrationRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.ComponentReplaceRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.SoftwareReworkRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.SoftwareDevelopmentRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.AccountRegistrationRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.AccountLossRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.AccountDisconnectRequests", new[] { "SubdivisionId" });
            DropIndex("dbo.AccountCancellationRequests", new[] { "SubdivisionId" });
            DropColumn("dbo.VideoCommunicationRequests", "SubdivisionId");
            DropColumn("dbo.PhoneRepairRequests", "SubdivisionId");
            DropColumn("dbo.PhoneNumberAllocationRequests", "SubdivisionId");
            DropColumn("dbo.PhoneLineRepairRequests", "SubdivisionId");
            DropColumn("dbo.NetworkConnectionRequests", "SubdivisionId");
            DropColumn("dbo.HoldingPhoneLineRequests", "SubdivisionId");
            DropColumn("dbo.EquipmentReplaceRequests", "SubdivisionId");
            DropColumn("dbo.EquipmentRepairRequests", "SubdivisionId");
            DropColumn("dbo.EquipmentRefillRequests", "SubdivisionId");
            DropColumn("dbo.EquipmentInstallationRequests", "SubdivisionId");
            DropColumn("dbo.EmailSizeIncreaseRequests", "SubdivisionId");
            DropColumn("dbo.EmailRegistrationRequests", "SubdivisionId");
            DropColumn("dbo.ComponentReplaceRequests", "SubdivisionId");
            DropColumn("dbo.Permissions", "Name");
            DropColumn("dbo.SoftwareReworkRequests", "SubdivisionId");
            DropColumn("dbo.SoftwareDevelopmentRequests", "SubdivisionId");
            DropColumn("dbo.AccountRegistrationRequests", "SubdivisionId");
            DropColumn("dbo.AccountLossRequests", "SubdivisionId");
            DropColumn("dbo.AccountDisconnectRequests", "SubdivisionId");
            DropColumn("dbo.AccountCancellationRequests", "SubdivisionId");
        }
    }
}
