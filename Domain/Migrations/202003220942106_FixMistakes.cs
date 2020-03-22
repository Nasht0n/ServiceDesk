namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMistakes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RefuelingLimits", "Subdivision_Id", "dbo.Subdivisions");
            DropIndex("dbo.RefuelingLimits", new[] { "Subdivision_Id" });
            RenameColumn(table: "dbo.RefuelingLimits", name: "Subdivision_Id", newName: "SubdivisionId");
            AlterColumn("dbo.RefuelingLimits", "SubdivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.RefuelingLimits", "SubdivisionId");
            AddForeignKey("dbo.RefuelingLimits", "SubdivisionId", "dbo.Subdivisions", "Id", cascadeDelete: true);
            DropColumn("dbo.RefuelingLimits", "SubdvisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RefuelingLimits", "SubdvisionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.RefuelingLimits", "SubdivisionId", "dbo.Subdivisions");
            DropIndex("dbo.RefuelingLimits", new[] { "SubdivisionId" });
            AlterColumn("dbo.RefuelingLimits", "SubdivisionId", c => c.Int());
            RenameColumn(table: "dbo.RefuelingLimits", name: "SubdivisionId", newName: "Subdivision_Id");
            CreateIndex("dbo.RefuelingLimits", "Subdivision_Id");
            AddForeignKey("dbo.RefuelingLimits", "Subdivision_Id", "dbo.Subdivisions", "Id");
        }
    }
}
