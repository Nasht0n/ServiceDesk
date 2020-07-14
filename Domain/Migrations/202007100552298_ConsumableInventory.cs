namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsumableInventory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consumables", "InventoryNumber", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Consumables", "InventoryNumber");
        }
    }
}
