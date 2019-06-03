using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FitnessApp.Models;
using FitnessApp.Models.DAL;

namespace FitnessApp.Controllers
{
    public class Program_IshraneController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var program_Ishrane = db.Program_Ishrane.Include(p => p.Klijent);
            return View(program_Ishrane.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program_Ishrane program_Ishrane = db.Program_Ishrane.Find(id);
            if (program_Ishrane == null)
            {
                return HttpNotFound();
            }
            return View(program_Ishrane);
        }

        public ActionResult Create()
        {
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProgramIshraneId,CenaPrograma,OpisPrograma,KlijentId")] Program_Ishrane program_Ishrane)
        {
            if (ModelState.IsValid)
            {
                db.Program_Ishrane.Add(program_Ishrane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", program_Ishrane.KlijentId);
            return View(program_Ishrane);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program_Ishrane program_Ishrane = db.Program_Ishrane.Find(id);
            if (program_Ishrane == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", program_Ishrane.KlijentId);
            return View(program_Ishrane);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProgramIshraneId,CenaPrograma,OpisPrograma,KlijentId")] Program_Ishrane program_Ishrane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program_Ishrane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", program_Ishrane.KlijentId);
            return View(program_Ishrane);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program_Ishrane program_Ishrane = db.Program_Ishrane.Find(id);
            if (program_Ishrane == null)
            {
                return HttpNotFound();
            }
            return View(program_Ishrane);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Program_Ishrane program_Ishrane = db.Program_Ishrane.Find(id);
            db.Program_Ishrane.Remove(program_Ishrane);
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
