namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeContextChange : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ConnectionEquipments", new[] { "NetworkConnectionRequest_Id" });
            RenameColumn(table: "dbo.ConnectionEquipments", name: "NetworkConnectionRequest_Id", newName: "RequestId");
            AlterColumn("dbo.ConnectionEquipments", "RequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.ConnectionEquipments", "RequestId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ConnectionEquipments", new[] { "RequestId" });
            AlterColumn("dbo.ConnectionEquipments", "RequestId", c => c.Int());
            RenameColumn(table: "dbo.ConnectionEquipments", name: "RequestId", newName: "NetworkConnectionRequest_Id");
            CreateIndex("dbo.ConnectionEquipments", "NetworkConnectionRequest_Id");
        }
    }
}
