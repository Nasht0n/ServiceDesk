namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsumableConsumption : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsumableTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentRefillRequestConsumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestId = c.Int(nullable: false),
                        ConsumableId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consumables", t => t.ConsumableId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentRefillRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId)
                .Index(t => t.ConsumableId);
            
            AddColumn("dbo.Consumables", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consumables", "TypeId");
            AddForeignKey("dbo.Consumables", "TypeId", "dbo.ConsumableTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentRefillRequestConsumptions", "RequestId", "dbo.EquipmentRefillRequests");
            DropForeignKey("dbo.EquipmentRefillRequestConsumptions", "ConsumableId", "dbo.Consumables");
            DropForeignKey("dbo.Consumables", "TypeId", "dbo.ConsumableTypes");
            DropIndex("dbo.EquipmentRefillRequestConsumptions", new[] { "ConsumableId" });
            DropIndex("dbo.EquipmentRefillRequestConsumptions", new[] { "RequestId" });
            DropIndex("dbo.Consumables", new[] { "TypeId" });
            DropColumn("dbo.Consumables", "TypeId");
            DropTable("dbo.EquipmentRefillRequestConsumptions");
            DropTable("dbo.ConsumableTypes");
        }
    }
}
