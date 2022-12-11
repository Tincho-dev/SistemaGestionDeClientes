namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Facturas", "Descripcion");
            DropColumn("dbo.Facturas", "Precio");
            DropColumn("dbo.Facturas", "Cantidad");
            DropColumn("dbo.Facturas", "Subtotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Facturas", "Subtotal", c => c.Double(nullable: false));
            AddColumn("dbo.Facturas", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Facturas", "Precio", c => c.Double(nullable: false));
            AddColumn("dbo.Facturas", "Descripcion", c => c.String());
        }
    }
}
