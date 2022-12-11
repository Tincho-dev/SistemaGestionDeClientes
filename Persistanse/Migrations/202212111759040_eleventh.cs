namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eleventh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Telefono", c => c.Long(nullable: false));
            AlterColumn("dbo.Empleadoes", "Telefono", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Empleadoes", "Telefono", c => c.Int(nullable: false));
            AlterColumn("dbo.Clientes", "Telefono", c => c.Int(nullable: false));
        }
    }
}
