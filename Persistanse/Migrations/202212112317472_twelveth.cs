namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twelveth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "Id_Proyecto", "dbo.Proyectos");
            DropIndex("dbo.Facturas", new[] { "Id_Proyecto" });
            DropColumn("dbo.Facturas", "Id_Proyecto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Id_Proyecto", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "Id_Proyecto");
            AddForeignKey("dbo.Facturas", "Id_Proyecto", "dbo.Proyectos", "Id_Proyecto", cascadeDelete: true);
        }
    }
}
