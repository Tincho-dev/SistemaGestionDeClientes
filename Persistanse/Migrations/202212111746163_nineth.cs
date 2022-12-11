namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nineth : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Telefono", c => c.Int(nullable: false));
        }
    }
}
