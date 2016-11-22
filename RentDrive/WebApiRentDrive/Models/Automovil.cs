using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRentDrive.Models
{
    public class Automovil
    {
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public byte Pasajeros { get; set; }
        public string Color { get; set; }
        public decimal PrecioRenta { get; set; }
        public DateTime AñoFabricacion { get; set; }
        public string TipoUnidad { get; set; }
        public string TipoSeguro { get; set; }

        public int ProveedorId { get; set; }
        public int SucursalId { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual Sucursal Sucursal { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}