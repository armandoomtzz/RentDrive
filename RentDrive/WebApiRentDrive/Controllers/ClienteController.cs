#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRentDrive.Models;
#endregion

namespace WebApiRentDrive.Controllers
{
    public class ClienteController : ApiController
    {
        //Objeto para el context.
        private RentDriveContext db = new RentDriveContext();

        #region Metodo GET de Cliente.
        // GET: api/Cliente
        public List<Cliente> Get()
        {
            return db.Clientes.ToList();
        }
        #endregion

        #region Metodo GET de Cliente por seleccion.
        // GET: api/Cliente/5
        public List<Cliente> Get(int id)
        {
            return db.Clientes.Where(s => s.Id == id).ToList();
        }
        #endregion

        #region Metodo POST de Cliente.
        // POST: api/Cliente
        public bool Post(int id, string nombre, string apellidoPaterno, string apellidoMaterno, int edad, string calle, string colonia, string ciudad, string estado, string telefonoCasa, string tipo)
        {
            var s = new Cliente()
            {
                Id = id,
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                Edad = edad,
                Calle = calle,
                Colonia = colonia,
                Ciudad = ciudad,
                Estado = estado,
                TelefonoCasa = telefonoCasa,
                Tipo = tipo
            };

            db.Clientes.Attach(s);
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;

            return db.SaveChanges() > 0;
        }
        #endregion

        #region Metodo PUT de Cliente.
        // PUT: api/Cliente/5
        public bool Put(int id, string nombre, string apellidoPaterno, string apellidoMaterno, int edad, string calle, string colonia, string ciudad, string estado, string telefonoCasa, string tipo)
        {
            var s = new Cliente()
            {
                Id = id,
                Nombre = nombre,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                Edad = edad,
                Calle = calle,
                Colonia = colonia,
                Ciudad = ciudad,
                Estado = estado,
                TelefonoCasa = telefonoCasa,
                Tipo = tipo
            };

            db.Clientes.Add(s);

            return db.SaveChanges() > 0;
        }
        #endregion

        #region Metodo DELETE de Cliente.
        // DELETE: api/Cliente/5
        public bool Delete(int id)
        {
            var s = db.Clientes.Find(id);

            db.Clientes.Attach(s);
            db.Clientes.Remove(s);

            return db.SaveChanges() > 0;
        }
        #endregion
    }
}
