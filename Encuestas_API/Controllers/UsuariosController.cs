using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Encuestas_API.Models;

namespace Encuestas_API.Controllers
{
    public class UsuariosController : Controller
    {
        private EncAppEntitites db = new EncAppEntitites();

        // GET: Usuarios
        public ActionResult Index()
        {
            var eNC_USUARIOS = db.ENC_USUARIOS.Include(e => e.ENC_ROLES);
            return View(eNC_USUARIOS.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            if (eNC_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(eNC_USUARIOS);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.IDROLES = new SelectList(db.ENC_ROLES, "IDROLES", "TIPOROL");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUSUARIO,IDROLES,NOMBREUSUARIO,PASSWORD,FECHACREACION,ESTATUS")] ENC_USUARIOS eNC_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.ENC_USUARIOS.Add(eNC_USUARIOS);
                eNC_USUARIOS.FECHACREACION = DateTime.Now;
                eNC_USUARIOS.ESTATUS = "A";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDROLES = new SelectList(db.ENC_ROLES, "IDROLES", "TIPOROL", eNC_USUARIOS.IDROLES);
            return View(eNC_USUARIOS);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            if (eNC_USUARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDROLES = new SelectList(db.ENC_ROLES, "IDROLES", "TIPOROL", eNC_USUARIOS.IDROLES);
            return View(eNC_USUARIOS);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUSUARIO,IDROLES,NOMBREUSUARIO,PASSWORD,FECHACREACION,ESTATUS")] ENC_USUARIOS eNC_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNC_USUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDROLES = new SelectList(db.ENC_ROLES, "IDROLES", "TIPOROL", eNC_USUARIOS.IDROLES);
            return View(eNC_USUARIOS);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(decimal? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            if (eNC_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(eNC_USUARIOS);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ENC_USUARIOS eNC_USUARIOS = db.ENC_USUARIOS.Find(id);
            db.ENC_USUARIOS.Remove(eNC_USUARIOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
