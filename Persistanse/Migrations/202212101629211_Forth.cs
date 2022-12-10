namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Id_Historial", "dbo.Historials");
            DropIndex("dbo.Facturas", new[] { "Id_Historial" });
            DropColumn("dbo.Facturas", "Id_Historial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Id_Historial", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "Id_Historial");
            AddForeignKey("dbo.Facturas", "Id_Historial", "dbo.Historials", "Id_Historial", cascadeDelete: true);
        }
    }
}
