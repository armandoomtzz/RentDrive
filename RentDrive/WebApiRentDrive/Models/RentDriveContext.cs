using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApiRentDrive.Models
{
    public class RentDriveContext : DbContext
    {
        public RentDriveContext() : base("RentDriveContext")
        {

        }

        public DbSet<Automovil> Automoviles { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Reserva> Reservaciones { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}