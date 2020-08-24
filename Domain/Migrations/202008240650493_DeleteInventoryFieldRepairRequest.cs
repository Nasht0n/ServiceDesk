namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteInventoryFieldRepairRequest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EquipmentRepairRequests", "InventoryNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EquipmentRepairRequests", "InventoryNumber", c => c.String(nullable: false));
        }
    }
}
