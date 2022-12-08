namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Id_Domicilio", "dbo.Domicilios");
            DropIndex("dbo.Clientes", new[] { "Id_Domicilio" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Clientes", "Id_Domicilio");
            AddForeignKey("dbo.Clientes", "Id_Domicilio", "dbo.Domicilios", "Id_Domicilio", cascadeDelete: true);
        }
    }
}
