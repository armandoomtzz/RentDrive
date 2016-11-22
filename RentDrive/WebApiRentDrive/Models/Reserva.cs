using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRentDrive.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaReserva { get; set; }
        public Decimal Monto { get; set; }

        public int ClienteId { get; set; }
        public int AutomovilId { get; set; }
        public int SucursalId { get; set; }

        public virtual Sucursal Sucursal { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Automovil Automovil { get; set; }
    }
}