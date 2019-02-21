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
    public class Enc_UsuariosController : ApiController
    {
        private EncAppEntitites db = new EncAppEntitites();

        // GET: api/Enc_Usuarios
        public IHttpActionResult GetENC_USUARIOS()
        {
            var person = (from p in db.ENC_USUARIOS
                          join e in db.ENC_EMPLEADOS
                          on p.IDUSUARIO equals e.IDUSUARIO
                          where p.IDUSUARIO == e.IDUSUARIO
                          select new
                          {
                              IDUSUARIO = p.IDUSUARIO,
                              IDROLES = p.IDROLES,
                              NOMBREUSUARIO = p.NOMBREUSUARIO,
                              PASSWORD = p.PASSWORD,
                              FECHACREACION = p.FECHACREACION,
                              ESTATUS = p.ESTATUS,
                              IDEMPLEADO = e.IDEMPLEADO,
                              NOMBREEMPLEADO = e.NOMBREEMPLEADO,
                              EMAIL = e.EMAIL,
                              TELEFONO = e.TELEFONO

                          });
            return Ok(person.ToList());

        }

        // GET: api/Enc_Usuarios/5
        [ResponseType(typeof(ENC_USUARIOS))]
        public IHttpActionResult GetENC_USUARIOS(decimal id)
        {
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            if (eNC_USUARIOS == null)
            {
                return NotFound();
            }

            return Ok(eNC_USUARIOS);
        }

        // PUT: api/Enc_Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutENC_USUARIOS(decimal id, ENC_USUARIOS eNC_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eNC_USUARIOS.IDUSUARIO)
            {
                return BadRequest();
            }

            db.Entry(eNC_USUARIOS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ENC_USUARIOSExists(id))
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

        // POST: api/Enc_Usuarios
        [ResponseType(typeof(ENC_USUARIOS))]
        public IHttpActionResult PostENC_USUARIOS(ENC_USUARIOS eNC_USUARIOS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ENC_USUARIOS.Add(eNC_USUARIOS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ENC_USUARIOSExists(eNC_USUARIOS.IDUSUARIO))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eNC_USUARIOS.IDUSUARIO }, eNC_USUARIOS);
        }

        // DELETE: api/Enc_Usuarios/5
        [ResponseType(typeof(ENC_USUARIOS))]
        public IHttpActionResult DeleteENC_USUARIOS(decimal id)
        {
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            if (eNC_USUARIOS == null)
            {
                return NotFound();
            }

            db.ENC_USUARIOS.Remove(eNC_USUARIOS);
            db.SaveChanges();

            return Ok(eNC_USUARIOS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ENC_USUARIOSExists(decimal id)
        {
            return db.ENC_USUARIOS.Count(e => e.IDUSUARIO == id) > 0;
        }
    }
}