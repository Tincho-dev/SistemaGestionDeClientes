namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleEmitidoes", "Id_Detalle", "dbo.Detalles");
            DropForeignKey("dbo.FacturaEmitidas", "Id_Factura", "dbo.Facturas");
            DropForeignKey("dbo.DetalleEmitidoes", "Id_Factura", "dbo.FacturaEmitidas");
            DropPrimaryKey("dbo.DetalleEmitidoes");
            DropPrimaryKey("dbo.FacturaEmitidas");
            AddColumn("dbo.DetalleEmitidoes", "Id_DetalleEmitido", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.FacturaEmitidas", "Id_FacturaEmitida", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DetalleEmitidoes", "Id_DetalleEmitido");
            AddPrimaryKey("dbo.FacturaEmitidas", "Id_FacturaEmitida");
            AddForeignKey("dbo.DetalleEmitidoes", "Id_Detalle", "dbo.Detalles", "Id_Detalle", cascadeDelete: false);
            AddForeignKey("dbo.FacturaEmitidas", "Id_Factura", "dbo.Facturas", "Id_Factura", cascadeDelete: false);
            AddForeignKey("dbo.DetalleEmitidoes", "Id_Factura", "dbo.FacturaEmitidas", "Id_FacturaEmitida", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleEmitidoes", "Id_Factura", "dbo.FacturaEmitidas");
            DropForeignKey("dbo.FacturaEmitidas", "Id_Factura", "dbo.Facturas");
            DropForeignKey("dbo.DetalleEmitidoes", "Id_Detalle", "dbo.Detalles");
            DropPrimaryKey("dbo.FacturaEmitidas");
            DropPrimaryKey("dbo.DetalleEmitidoes");
            DropColumn("dbo.FacturaEmitidas", "Id_FacturaEmitida");
            DropColumn("dbo.DetalleEmitidoes", "Id_DetalleEmitido");
            AddPrimaryKey("dbo.FacturaEmitidas", "Id_Factura");
            AddPrimaryKey("dbo.DetalleEmitidoes", "Id_Detalle");
            AddForeignKey("dbo.DetalleEmitidoes", "Id_Factura", "dbo.FacturaEmitidas", "Id_FacturaEmitida", cascadeDelete: true);
            AddForeignKey("dbo.FacturaEmitidas", "Id_Factura", "dbo.Facturas", "Id_Factura");
            AddForeignKey("dbo.DetalleEmitidoes", "Id_Detalle", "dbo.Detalles", "Id_Detalle");
        }
    }
}
