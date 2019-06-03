using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FitnessApp.Models;
using FitnessApp.Models.DAL;

namespace FitnessApp.Controllers
{
    public class Clanska_KartaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var clanska_Karta = db.Clanska_Karta.Include(c => c.Klijent);
            return View(clanska_Karta.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanska_Karta clanska_Karta = db.Clanska_Karta.Find(id);
            if (clanska_Karta == null)
            {
                return HttpNotFound();
            }
            return View(clanska_Karta);
        }

        public ActionResult Create()
        {
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClanskaKartaId,Cena,DatumUplate,DatumVazenja,BrojKarte,KlijentId")] Clanska_Karta clanska_Karta)
        {
            if (ModelState.IsValid)
            {
                db.Clanska_Karta.Add(clanska_Karta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", clanska_Karta.KlijentId);
            return View(clanska_Karta);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanska_Karta clanska_Karta = db.Clanska_Karta.Find(id);
            if (clanska_Karta == null)
            {
                return HttpNotFound();
            }
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", clanska_Karta.KlijentId);
            return View(clanska_Karta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClanskaKartaId,Cena,DatumUplate,DatumVazenja,BrojKarte,KlijentId")] Clanska_Karta clanska_Karta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clanska_Karta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", clanska_Karta.KlijentId);
            return View(clanska_Karta);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clanska_Karta clanska_Karta = db.Clanska_Karta.Find(id);
            if (clanska_Karta == null)
            {
                return HttpNotFound();
            }
            return View(clanska_Karta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clanska_Karta clanska_Karta = db.Clanska_Karta.Find(id);
            db.Clanska_Karta.Remove(clanska_Karta);
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
