namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesDb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RepairEquipments", "ConsumableId", "dbo.Consumables");
            DropIndex("dbo.RepairEquipments", new[] { "ConsumableId" });
            CreateTable(
                "dbo.EquipmentRepairRequestConsumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        ConsumableId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumables", t => t.ConsumableId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentRepairRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.ConsumableId);
            
            AddColumn("dbo.RepairEquipments", "InventoryNumber", c => c.String());
            DropColumn("dbo.RepairEquipments", "Count");
            DropColumn("dbo.RepairEquipments", "ConsumableId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RepairEquipments", "ConsumableId", c => c.Int(nullable: false));
            AddColumn("dbo.RepairEquipments", "Count", c => c.Int(nullable: false));
            DropForeignKey("dbo.EquipmentRepairRequestConsumptions", "RequestId", "dbo.EquipmentRepairRequests");
            DropForeignKey("dbo.EquipmentRepairRequestConsumptions", "ConsumableId", "dbo.Consumables");
            DropIndex("dbo.EquipmentRepairRequestConsumptions", new[] { "ConsumableId" });
            DropIndex("dbo.EquipmentRepairRequestConsumptions", new[] { "RequestId" });
            DropColumn("dbo.RepairEquipments", "InventoryNumber");
            DropTable("dbo.EquipmentRepairRequestConsumptions");
            CreateIndex("dbo.RepairEquipments", "ConsumableId");
            AddForeignKey("dbo.RepairEquipments", "ConsumableId", "dbo.Consumables", "Id", cascadeDelete: true);
        }
    }
}
