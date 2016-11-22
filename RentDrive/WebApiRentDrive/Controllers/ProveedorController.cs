using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRentDrive.Models;

namespace WebApiRentDrive.Controllers
{
    public class ProveedorController : ApiController
    {
        private RentDriveContext db = new RentDriveContext();
        // GET: api/Proveedor
        public List<Proveedor> Get()
        {
            return db.Proveedores.ToList();
        }

        // GET: api/Proveedor/5
        public List<Proveedor> Get(int id)
        {
            return db.Proveedores.Where(e => e.Id == id).ToList();
        }

        // POST: api/Proveedor
        public bool Post(int id, string nombre, string ciudad, string estado, string email, string telefono)
        {
            var p = new Proveedor()
            {
                Id = id,
                Nombre = nombre,
                Ciudad = ciudad,
                Estado = estado,
                Email = email,
                Telefono = telefono

            };
            db.Proveedores.Attach(p);
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Proveedor/5
        public bool Put(int id, string nombre, string ciudad, string estado, string email, string telefono)
        {
            var p = new Proveedor()
            {
                Id = id,
                Nombre = nombre,
                Ciudad = ciudad,
                Estado = estado,
                Email = email,
                Telefono = telefono

            };
            db.Proveedores.Add(p);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Proveedor/5
        public bool Delete(int id)
        {
            var d = db.Proveedores.Find(id);
            db.Proveedores.Attach(d);
            db.Proveedores.Remove(d);
            return db.SaveChanges() > 0;
        }
    }
}
