namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eighth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Detalles", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Detalles", "Descripcion");
        }
    }
}
