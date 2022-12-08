namespace Persistanse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        enabled = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Name = c.String(),
                        LastName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        DNI = c.Int(nullable: false, identity: true),
                        Telefono = c.Int(nullable: false),
                        Mail = c.String(maxLength: 150),
                        Condicion_Tributaria = c.String(maxLength: 150),
                        Nombre = c.String(maxLength: 150),
                        Apellido = c.String(maxLength: 150),
                        Id_Domicilio = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DNI)
                .ForeignKey("dbo.Domicilios", t => t.Id_Domicilio, cascadeDelete: true)
                .Index(t => t.Id_Domicilio);
            
            CreateTable(
                "dbo.Domicilios",
                c => new
                    {
                        Id_Domicilio = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        Barrio = c.String(),
                        Altura = c.String(),
                        Cod_Postal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Domicilio)
                .ForeignKey("dbo.Localidads", t => t.Cod_Postal, cascadeDelete: true)
                .Index(t => t.Cod_Postal);
            
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        Cod_Postal = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Id_Provincia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cod_Postal)
                .ForeignKey("dbo.Provincias", t => t.Id_Provincia, cascadeDelete: true)
                .Index(t => t.Id_Provincia);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        Id_Provincia = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Id_Pais = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Provincia)
                .ForeignKey("dbo.Pais", t => t.Id_Pais, cascadeDelete: true)
                .Index(t => t.Id_Pais);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        IdPais = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.IdPais);
            
            CreateTable(
                "dbo.Detalles",
                c => new
                    {
                        Id_Detalle = c.Int(nullable: false, identity: true),
                        PrecioUnitario = c.Double(nullable: false),
                        SubTotal = c.Double(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Id_Proyecto = c.Int(nullable: false),
                        Id_Factura = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Detalle)
                .ForeignKey("dbo.Facturas", t => t.Id_Factura, cascadeDelete: true)
                .ForeignKey("dbo.Proyectos", t => t.Id_Proyecto, cascadeDelete: true)
                .Index(t => t.Id_Proyecto)
                .Index(t => t.Id_Factura);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        Id_Factura = c.Int(nullable: false, identity: true),
                        Total = c.Double(nullable: false),
                        RutaCopiaOriginal = c.String(),
                        FechaEmision = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Id_Historial = c.Int(nullable: false),
                        LegajoEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Factura)
                .ForeignKey("dbo.Empleadoes", t => t.LegajoEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Historials", t => t.Id_Historial, cascadeDelete: true)
                .Index(t => t.Id_Historial)
                .Index(t => t.LegajoEmpleado);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Legajo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 120),
                        Apellido = c.String(nullable: false, maxLength: 120),
                        DNI = c.Int(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Id_Domicilio = c.Int(nullable: false),
                        Id_RolServicio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Legajo)
                .ForeignKey("dbo.Domicilios", t => t.Id_Domicilio, cascadeDelete: true)
                .ForeignKey("dbo.RolEmps", t => t.Id_RolServicio, cascadeDelete: true)
                .Index(t => t.Id_Domicilio)
                .Index(t => t.Id_RolServicio);
            
            CreateTable(
                "dbo.RolEmps",
                c => new
                    {
                        Id_Rol = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 120),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id_Rol);
            
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        Id_Historial = c.Int(nullable: false, identity: true),
                        SaldoAdeudado = c.Double(nullable: false),
                        Cliente_DNI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Historial)
                .ForeignKey("dbo.Clientes", t => t.Cliente_DNI, cascadeDelete: false)
                .Index(t => t.Cliente_DNI);
            
            CreateTable(
                "dbo.Proyectos",
                c => new
                    {
                        Id_Proyecto = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 180),
                        Descripcion = c.String(),
                        FechInicio = c.DateTime(nullable: false),
                        FechFin = c.DateTime(nullable: false),
                        Finalizado = c.Boolean(nullable: false),
                        Cliente_DNI = c.Int(nullable: false),
                        Costo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Proyecto)
                .ForeignKey("dbo.Clientes", t => t.Cliente_DNI, cascadeDelete: false)
                .Index(t => t.Cliente_DNI);
            
            CreateTable(
                "dbo.Llamadas",
                c => new
                    {
                        Id_Llamada = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Cliente_CUIT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Llamada)
                .ForeignKey("dbo.Clientes", t => t.Cliente_CUIT, cascadeDelete: true)
                .Index(t => t.Cliente_CUIT);
            
            CreateTable(
                "dbo.UserPorEmps",
                c => new
                    {
                        IdUserxEmp = c.Int(nullable: false, identity: true),
                        Legajo = c.Int(nullable: false),
                        IdUsuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.IdUserxEmp)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUsuario)
                .ForeignKey("dbo.Empleadoes", t => t.Legajo, cascadeDelete: true)
                .Index(t => t.Legajo)
                .Index(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserPorEmps", "Legajo", "dbo.Empleadoes");
            DropForeignKey("dbo.UserPorEmps", "IdUsuario", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Llamadas", "Cliente_CUIT", "dbo.Clientes");
            DropForeignKey("dbo.Detalles", "Id_Proyecto", "dbo.Proyectos");
            DropForeignKey("dbo.Proyectos", "Cliente_DNI", "dbo.Clientes");
            DropForeignKey("dbo.Detalles", "Id_Factura", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "Id_Historial", "dbo.Historials");
            DropForeignKey("dbo.Historials", "Cliente_DNI", "dbo.Clientes");
            DropForeignKey("dbo.Facturas", "LegajoEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "Id_RolServicio", "dbo.RolEmps");
            DropForeignKey("dbo.Empleadoes", "Id_Domicilio", "dbo.Domicilios");
            DropForeignKey("dbo.Clientes", "Id_Domicilio", "dbo.Domicilios");
            DropForeignKey("dbo.Domicilios", "Cod_Postal", "dbo.Localidads");
            DropForeignKey("dbo.Localidads", "Id_Provincia", "dbo.Provincias");
            DropForeignKey("dbo.Provincias", "Id_Pais", "dbo.Pais");
            DropIndex("dbo.UserPorEmps", new[] { "IdUsuario" });
            DropIndex("dbo.UserPorEmps", new[] { "Legajo" });
            DropIndex("dbo.Llamadas", new[] { "Cliente_CUIT" });
            DropIndex("dbo.Proyectos", new[] { "Cliente_DNI" });
            DropIndex("dbo.Historials", new[] { "Cliente_DNI" });
            DropIndex("dbo.Empleadoes", new[] { "Id_RolServicio" });
            DropIndex("dbo.Empleadoes", new[] { "Id_Domicilio" });
            DropIndex("dbo.Facturas", new[] { "LegajoEmpleado" });
            DropIndex("dbo.Facturas", new[] { "Id_Historial" });
            DropIndex("dbo.Detalles", new[] { "Id_Factura" });
            DropIndex("dbo.Detalles", new[] { "Id_Proyecto" });
            DropIndex("dbo.Provincias", new[] { "Id_Pais" });
            DropIndex("dbo.Localidads", new[] { "Id_Provincia" });
            DropIndex("dbo.Domicilios", new[] { "Cod_Postal" });
            DropIndex("dbo.Clientes", new[] { "Id_Domicilio" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.UserPorEmps");
            DropTable("dbo.Llamadas");
            DropTable("dbo.Proyectos");
            DropTable("dbo.Historials");
            DropTable("dbo.RolEmps");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Facturas");
            DropTable("dbo.Detalles");
            DropTable("dbo.Pais");
            DropTable("dbo.Provincias");
            DropTable("dbo.Localidads");
            DropTable("dbo.Domicilios");
            DropTable("dbo.Clientes");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
