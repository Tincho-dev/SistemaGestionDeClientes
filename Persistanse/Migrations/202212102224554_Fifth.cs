namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Historials", "Id_Cliente", "dbo.Clientes");
            DropIndex("dbo.Historials", new[] { "Id_Cliente" });
            AddColumn("dbo.Facturas", "LegajoEmpleado", c => c.Int(nullable: false));
            CreateIndex("dbo.Facturas", "LegajoEmpleado");
            AddForeignKey("dbo.Facturas", "LegajoEmpleado", "dbo.Empleadoes", "Legajo", cascadeDelete: true);
            DropTable("dbo.Historials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        Id_Historial = c.Int(nullable: false, identity: true),
                        SaldoAdeudado = c.Double(nullable: false),
                        Id_Cliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Historial);
            
            DropForeignKey("dbo.Facturas", "LegajoEmpleado", "dbo.Empleadoes");
            DropIndex("dbo.Facturas", new[] { "LegajoEmpleado" });
            DropColumn("dbo.Facturas", "LegajoEmpleado");
            CreateIndex("dbo.Historials", "Id_Cliente");
            AddForeignKey("dbo.Historials", "Id_Cliente", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
