using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FitnessApp.Models;
using FitnessApp.Models.DAL;

namespace FitnessApp.Controllers
{
    public class PersonalniTrenerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var klijent_trener = db.klijent_trener.Include(k => k.Klijent).Include(k => k.Trener);
            return View(klijent_trener.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime");
            ViewBag.TrenerId = new SelectList(db.Trener, "TrenerId", "Ime");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KlijentId,TrenerId,OpisTreninga")] klijent_trener klijent_trener)
        {
            if (ModelState.IsValid)
            {
                db.klijent_trener.Add(klijent_trener);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KlijentId = new SelectList(db.Klijent, "KlijentId", "Ime", klijent_trener.KlijentId);
            ViewBag.TrenerId = new SelectList(db.Trener, "TrenerId", "Ime", klijent_trener.TrenerId);
            return View(klijent_trener);
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
