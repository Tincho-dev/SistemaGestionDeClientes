namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Historials", name: "Cliente_DNI", newName: "Id_Cliente");
            RenameColumn(table: "dbo.Proyectos", name: "Cliente_DNI", newName: "Id_Cliente");
            RenameColumn(table: "dbo.Llamadas", name: "Cliente_CUIT", newName: "Id_Cliente");
            RenameIndex(table: "dbo.Historials", name: "IX_Cliente_DNI", newName: "IX_Id_Cliente");
            RenameIndex(table: "dbo.Proyectos", name: "IX_Cliente_DNI", newName: "IX_Id_Cliente");
            RenameIndex(table: "dbo.Llamadas", name: "IX_Cliente_CUIT", newName: "IX_Id_Cliente");
            AddColumn("dbo.Facturas", "Id_Cliente", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "Id_Proyecto", c => c.Int(nullable: false));
            AddColumn("dbo.Proyectos", "FechaInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Proyectos", "FechaFin", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Facturas", "Id_Cliente");
            CreateIndex("dbo.Facturas", "Id_Proyecto");
            AddForeignKey("dbo.Facturas", "Id_Cliente", "dbo.Clientes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Facturas", "Id_Proyecto", "dbo.Proyectos", "Id_Proyecto", cascadeDelete: false);
            DropColumn("dbo.Proyectos", "FechInicio");
            DropColumn("dbo.Proyectos", "FechFin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proyectos", "FechFin", c => c.DateTime(nullable: false));
            AddColumn("dbo.Proyectos", "FechInicio", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Facturas", "Id_Proyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Facturas", "Id_Cliente", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Id_Proyecto" });
            DropIndex("dbo.Facturas", new[] { "Id_Cliente" });
            DropColumn("dbo.Proyectos", "FechaFin");
            DropColumn("dbo.Proyectos", "FechaInicio");
            DropColumn("dbo.Facturas", "Id_Proyecto");
            DropColumn("dbo.Facturas", "Id_Cliente");
            RenameIndex(table: "dbo.Llamadas", name: "IX_Id_Cliente", newName: "IX_Cliente_CUIT");
            RenameIndex(table: "dbo.Proyectos", name: "IX_Id_Cliente", newName: "IX_Cliente_DNI");
            RenameIndex(table: "dbo.Historials", name: "IX_Id_Cliente", newName: "IX_Cliente_DNI");
            RenameColumn(table: "dbo.Llamadas", name: "Id_Cliente", newName: "Cliente_CUIT");
            RenameColumn(table: "dbo.Proyectos", name: "Id_Cliente", newName: "Cliente_DNI");
            RenameColumn(table: "dbo.Historials", name: "Id_Cliente", newName: "Cliente_DNI");
        }
    }
}
