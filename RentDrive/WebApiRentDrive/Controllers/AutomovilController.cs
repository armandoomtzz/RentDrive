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
    public class AutomovilController : ApiController
    {
        //Objeto para el context.
        private RentDriveContext db = new RentDriveContext();

        #region Metodo GET para Automovil.
        // GET: api/Automovil
        public List<Automovil> Get()
        {
            return db.Automoviles.ToList();
        }
        #endregion

        #region Metodo GET para Automovil por seleccion.
        // GET: api/Automovil/5
        public List<Automovil> Get(int id)
        {
            return db.Automoviles.Where(s => s.Id == id).ToList();
        }
        #endregion

        #region Metodo POST de Automovil.
        // POST: api/Automovil
        public bool Post(int id, string matricula, string marca, string modelo, byte pasajeros, string color, decimal precioRenta, DateTime añoFabricacion, string tipoUnidad, string tipoSeguro, int proveedorId, int sucursalId)
        {
            var s = new Automovil()
            {
                Id = id,
                Matricula = matricula,
                Marca = marca,
                Modelo = modelo,
                Pasajeros = pasajeros,
                Color = color,
                PrecioRenta = precioRenta,
                AñoFabricacion = añoFabricacion,
                TipoUnidad = tipoUnidad,
                TipoSeguro = tipoSeguro,
                ProveedorId = proveedorId,
                SucursalId = sucursalId
            };

            db.Automoviles.Attach(s);
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;

            return db.SaveChanges() > 0;
        }
        #endregion

        #region Metodo PUT de Automovil.
        // PUT: api/Automovil/5
        public bool Put(int id, string matricula, string marca, string modelo, byte pasajeros, string color, decimal precioRenta, DateTime añoFabricacion, string tipoUnidad, string tipoSeguro, int proveedorId, int sucursalId)
        {
            var s = new Automovil()
            {
                Id = id,
                Matricula = matricula,
                Marca = marca,
                Modelo = modelo,
                Pasajeros = pasajeros,
                Color = color,
                PrecioRenta = precioRenta,
                AñoFabricacion = añoFabricacion,
                TipoUnidad = tipoUnidad,
                TipoSeguro = tipoSeguro,
                ProveedorId = proveedorId,
                SucursalId = sucursalId
            };

            db.Automoviles.Add(s);

            return db.SaveChanges() > 0;
        }
        #endregion

        #region Metodo DELETE de Automovil.
        // DELETE: api/Automovil/5
        public bool Delete(int id)
        {
            var s = db.Automoviles.Find(id);

            db.Automoviles.Attach(s);
            db.Automoviles.Remove(s);

            return db.SaveChanges() > 0;
        }
        #endregion
    }
}
