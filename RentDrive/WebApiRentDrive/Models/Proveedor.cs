using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRentDrive.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Automovil> Automovil { get; set; }
    }
}