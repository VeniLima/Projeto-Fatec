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
    public class HorasController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Horas
        public ActionResult Index()
        {
            var horas = db.Horas.Include(h => h.Funcionarios);
            return View(horas.ToList());
        }

        // GET: Horas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas horas = db.Horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            return View(horas);
        }

        // GET: Horas/Create
        public ActionResult Create()
        {
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome");
            return View();
        }

        // POST: Horas/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Horas1,Periodo,Funcionario")] Horas horas)
        {
            if (ModelState.IsValid)
            {
                db.Horas.Add(horas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", horas.Funcionario);
            return View(horas);
        }

        // GET: Horas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas horas = db.Horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", horas.Funcionario);
            return View(horas);
        }

        // POST: Horas/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Horas1,Periodo,Funcionario")] Horas horas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Funcionario = new SelectList(db.Funcionarios, "Id", "Nome", horas.Funcionario);
            return View(horas);
        }

        // GET: Horas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Horas horas = db.Horas.Find(id);
            if (horas == null)
            {
                return HttpNotFound();
            }
            return View(horas);
        }

        // POST: Horas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horas horas = db.Horas.Find(id);
            db.Horas.Remove(horas);
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
