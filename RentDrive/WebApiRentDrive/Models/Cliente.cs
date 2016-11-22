using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRentDrive.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Edad { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string TelefonoCasa { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}