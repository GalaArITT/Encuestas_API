using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Encuestas_API.Models;

namespace Encuestas_API.Controllers
{
    public class Enc_EmpleadosController : ApiController
    {
        private EncAppEntitites db = new EncAppEntitites();

        // GET: api/Enc_Empleados
        public IQueryable<ENC_EMPLEADOS> GetENC_EMPLEADOS()
        {
            return db.ENC_EMPLEADOS;
        }

        // GET: api/Enc_Empleados/5
        [ResponseType(typeof(ENC_EMPLEADOS))]
        public IHttpActionResult GetENC_EMPLEADOS(decimal id)
        {
            ENC_EMPLEADOS eNC_EMPLEADOS = db.ENC_EMPLEADOS.Find(id);
            if (eNC_EMPLEADOS == null)
            {
                return NotFound();
            }

            return Ok(eNC_EMPLEADOS);
        }

        // PUT: api/Enc_Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutENC_EMPLEADOS(decimal id, ENC_EMPLEADOS eNC_EMPLEADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eNC_EMPLEADOS.IDEMPLEADO)
            {
                return BadRequest();
            }

            db.Entry(eNC_EMPLEADOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ENC_EMPLEADOSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Enc_Empleados
        [ResponseType(typeof(ENC_EMPLEADOS))]
        public IHttpActionResult PostENC_EMPLEADOS(ENC_EMPLEADOS eNC_EMPLEADOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ENC_EMPLEADOS.Add(eNC_EMPLEADOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ENC_EMPLEADOSExists(eNC_EMPLEADOS.IDEMPLEADO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eNC_EMPLEADOS.IDEMPLEADO }, eNC_EMPLEADOS);
        }

        // DELETE: api/Enc_Empleados/5
        [ResponseType(typeof(ENC_EMPLEADOS))]
        public IHttpActionResult DeleteENC_EMPLEADOS(decimal id)
        {
            ENC_EMPLEADOS eNC_EMPLEADOS = db.ENC_EMPLEADOS.Find(id);
            if (eNC_EMPLEADOS == null)
            {
                return NotFound();
            }

            db.ENC_EMPLEADOS.Remove(eNC_EMPLEADOS);
            db.SaveChanges();

            return Ok(eNC_EMPLEADOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ENC_EMPLEADOSExists(decimal id)
        {
            return db.ENC_EMPLEADOS.Count(e => e.IDEMPLEADO == id) > 0;
        }
    }
}