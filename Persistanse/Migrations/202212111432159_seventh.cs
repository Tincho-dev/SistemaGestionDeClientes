namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seventh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Id_RolServicio", "dbo.RolEmps");
            DropIndex("dbo.Empleadoes", new[] { "Id_RolServicio" });
            DropColumn("dbo.Empleadoes", "Id_RolServicio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empleadoes", "Id_RolServicio", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleadoes", "Id_RolServicio");
            AddForeignKey("dbo.Empleadoes", "Id_RolServicio", "dbo.RolEmps", "Id_Rol", cascadeDelete: true);
        }
    }
}
