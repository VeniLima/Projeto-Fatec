using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgoraVaiRecursosHumanos.Models;

namespace AgoraVaiRecursosHumanos.Controllers
{
    public class CargosController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Cargos
        public ActionResult Index()
        {
            if(Session.Count != 0)
            {
                return View(db.Cargos.ToList());
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargos cargos = db.Cargos.Find(id);
                if (cargos == null)
                {
                    return HttpNotFound();
                }
                return View(cargos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            if (Session.Count != 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
            
        }

        // POST: Cargos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Meta")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(cargos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cargos);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargos cargos = db.Cargos.Find(id);
                if (cargos == null)
                {
                    return HttpNotFound();
                }
                return View(cargos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // POST: Cargos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Meta")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cargos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cargos);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cargos cargos = db.Cargos.Find(id);
                if (cargos == null)
                {
                    return HttpNotFound();
                }
                return View(cargos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

           
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargos cargos = db.Cargos.Find(id);
            db.Cargos.Remove(cargos);
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
