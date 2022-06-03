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
    public class FuncionariosController : Controller
    {
        private Database1Entities db = new Database1Entities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            if (Session.Count != 0)
            {
                var funcionarios = db.Funcionarios.Include(f => f.Cargos).Include(f => f.Departamentos);
            return View(funcionarios.ToList());
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (Session.Count != 0)
            {
                 if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
                return View(funcionarios);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

           
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            if (Session.Count != 0)
            {
                ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nome");
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nome");
            return View();
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

           
        }

        // POST: Funcionarios/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Cep,Idade,Cargo,Departamento")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Funcionarios.Add(funcionarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nome", funcionarios.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nome", funcionarios.Departamento);
            return View(funcionarios);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session.Count != 0)
            {
                if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nome", funcionarios.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nome", funcionarios.Departamento);
            return View(funcionarios);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

            
        }

        // POST: Funcionarios/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf,Cep,Idade,Cargo,Departamento")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo = new SelectList(db.Cargos, "Id", "Nome", funcionarios.Cargo);
            ViewBag.Departamento = new SelectList(db.Departamentos, "Id", "Nome", funcionarios.Departamento);
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session.Count != 0)
            {
                 if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            if (funcionarios == null)
            {
                return HttpNotFound();
            }
            return View(funcionarios);
            }
            else
            {
                return RedirectToAction("Error", "Home");
            }

           
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Funcionarios funcionarios = db.Funcionarios.Find(id);
            db.Funcionarios.Remove(funcionarios);
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
