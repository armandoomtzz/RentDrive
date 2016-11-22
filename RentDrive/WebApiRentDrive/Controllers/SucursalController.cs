using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRentDrive.Models;

namespace WebApiRentDrive.Controllers
{
    public class SucursalController : ApiController
    {
        private RentDriveContext db = new RentDriveContext();
        // GET: api/Sucursal
        public List<Sucursal> Get()
        {
            return db.Sucursales.ToList();
        }

        // GET: api/Sucursal/5
        public List<Sucursal> Get(int id)
        {
            return db.Sucursales.Where(e => e.Id == id).ToList();
        }

        // POST: api/Sucursal
        public bool Post(int id, string nombre, string calle, string ciudad, string colonia)
        {
            var s = new Sucursal()
            {
                Id = id,
                Nombre = nombre,
                Calle = calle,
                Ciudad = ciudad,
                Colonia = colonia,

            };
            db.Sucursales.Attach(s);
            db.Entry(s).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Sucursal/5
        public bool Put(int id, string nombre, string calle, string ciudad, string colonia)
        {
            var s = new Sucursal()
            {
                Id = id,
                Nombre = nombre,
                Calle = calle,
                Ciudad = ciudad,
                Colonia = colonia,
            };
            db.Sucursales.Add(s);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Sucursal/5
        public bool Delete(int id)
        {
            var d = db.Sucursales.Find(id);
            db.Sucursales.Attach(d);
            db.Sucursales.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
