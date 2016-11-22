using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRentDrive.Models;

namespace WebApiRentDrive.Controllers
{
    public class ReservaController : ApiController
    {
        private RentDriveContext db = new RentDriveContext();
        // GET: api/Reserva
        public List<Reserva> Get()
        {
            return db.Reservaciones.ToList();
        }

        // GET: api/Reserva/5
        public List<Reserva> Get(int id)
        {
            return db.Reservaciones.Where(e => e.Id == id).ToList();
        }

        // POST: api/Reserva
        public bool Post(int id, string monto, string fechaReserva, int clienteid, int susursalid, int automovilid)
        {
            var r = new Reserva()
            {
                Id = id,
                Monto = Convert.ToDecimal(monto),
                FechaReserva = Convert.ToDateTime(fechaReserva),
                ClienteId = clienteid,
                SucursalId = susursalid,
                AutomovilId = automovilid
            };
            db.Reservaciones.Attach(r);
            db.Entry(r).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = true;
            return db.SaveChanges() > 0;
        }

        // PUT: api/Reserva/5
        public bool Put(int id, string monto, string fechaReserva, int clienteid, int susursalid, int automovilid)
        {
            var r = new Reserva()
            {
                Id = id,
                Monto = Convert.ToDecimal(monto),
                FechaReserva = Convert.ToDateTime(fechaReserva),
                ClienteId = clienteid,
                SucursalId = susursalid,
                AutomovilId = automovilid
            };
            db.Reservaciones.Add(r);
            return db.SaveChanges() > 0;
        }

        // DELETE: api/Reserva/5
        public bool Delete(int id)
        {
            var r = db.Reservaciones.Find(id);
            db.Reservaciones.Attach(r);
            db.Reservaciones.Remove(r);
            return db.SaveChanges() > 0;
        }
    }
}
