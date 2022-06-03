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
    public class DepartamentosController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Departamentos
        public ActionResult Index()
        {
            if (Session.Count != 0)
            {
               return View(db.Departamentos.ToList());
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
           
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // GET: Departamentos/Create
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

        // POST: Departamentos/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao")] Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Departamentos.Add(departamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamentos);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // POST: Departamentos/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao")] Departamentos departamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentos);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session.Count != 0)
            {
                  if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamentos departamentos = db.Departamentos.Find(id);
            if (departamentos == null)
            {
                return HttpNotFound();
            }
            return View(departamentos);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }
          
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamentos departamentos = db.Departamentos.Find(id);
            db.Departamentos.Remove(departamentos);
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
