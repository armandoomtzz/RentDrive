namespace WebApiRentDrive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Automovil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Pasajeros = c.Byte(nullable: false),
                        Color = c.String(),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AñoFabricacion = c.DateTime(nullable: false),
                        TipoUnidad = c.String(),
                        TipoSeguro = c.String(),
                        ProveedorId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proveedor", t => t.ProveedorId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursal", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.ProveedorId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Ciudad = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reserva",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaReserva = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClienteId = c.Int(nullable: false),
                        AutomovilId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Automovil", t => t.AutomovilId, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursal", t => t.SucursalId, cascadeDelete: false)
                .Index(t => t.ClienteId)
                .Index(t => t.AutomovilId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Edad = c.Int(nullable: false),
                        Calle = c.String(),
                        Colonia = c.String(),
                        Ciudad = c.String(),
                        Estado = c.String(),
                        TelefonoCasa = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sucursal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Calle = c.String(),
                        Colonia = c.String(),
                        Ciudad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reserva", "SucursalId", "dbo.Sucursal");
            DropForeignKey("dbo.Automovil", "SucursalId", "dbo.Sucursal");
            DropForeignKey("dbo.Reserva", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Reserva", "AutomovilId", "dbo.Automovil");
            DropForeignKey("dbo.Automovil", "ProveedorId", "dbo.Proveedor");
            DropIndex("dbo.Reserva", new[] { "SucursalId" });
            DropIndex("dbo.Reserva", new[] { "AutomovilId" });
            DropIndex("dbo.Reserva", new[] { "ClienteId" });
            DropIndex("dbo.Automovil", new[] { "SucursalId" });
            DropIndex("dbo.Automovil", new[] { "ProveedorId" });
            DropTable("dbo.Sucursal");
            DropTable("dbo.Cliente");
            DropTable("dbo.Reserva");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Automovil");
        }
    }
}
