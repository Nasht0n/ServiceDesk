namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 255),
                        Shortname = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Consumables", "UnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consumables", "UnitId");
            AddForeignKey("dbo.Consumables", "UnitId", "dbo.Units", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consumables", "UnitId", "dbo.Units");
            DropIndex("dbo.Consumables", new[] { "UnitId" });
            DropColumn("dbo.Consumables", "UnitId");
            DropTable("dbo.Units");
        }
    }
}
