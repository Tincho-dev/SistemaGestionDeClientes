namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Facturas", "LegajoEmpleado", "dbo.Empleadoes");
            DropIndex("dbo.Facturas", new[] { "LegajoEmpleado" });
            AddColumn("dbo.Facturas", "Descripcion", c => c.String());
            AddColumn("dbo.Facturas", "Precio", c => c.Double(nullable: false));
            AddColumn("dbo.Facturas", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "Subtotal", c => c.Double(nullable: false));
            DropColumn("dbo.Facturas", "RutaCopiaOriginal");
            DropColumn("dbo.Facturas", "LegajoEmpleado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "LegajoEmpleado", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "RutaCopiaOriginal", c => c.String());
            DropColumn("dbo.Facturas", "Subtotal");
            DropColumn("dbo.Facturas", "Cantidad");
            DropColumn("dbo.Facturas", "Precio");
            DropColumn("dbo.Facturas", "Descripcion");
            CreateIndex("dbo.Facturas", "LegajoEmpleado");
            AddForeignKey("dbo.Facturas", "LegajoEmpleado", "dbo.Empleadoes", "Legajo", cascadeDelete: true);
        }
    }
}
