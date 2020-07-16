namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnitConsumption : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.EquipmentRefillRequestConsumptions", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EquipmentRefillRequestConsumptions", "Unit", c => c.String());
        }
    }
}
