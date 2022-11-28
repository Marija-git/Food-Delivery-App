using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dostava_projekat.Models;
using Dostava_projekat.Models.DataDb;

namespace Dostava_projekat.Controllers
{
    public class KorisnikController : Controller
    {
        private EFCodeFirstEntities db = new EFCodeFirstEntities();

        // GET: Korisnik
        public ActionResult Index()
        {
            return View(db.Korisnici.ToList());
        }

        // GET: Korisnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: Korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korisnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KorisnikId,KorisnickoIme,Email,Lozinka,Ime,Prezime,DatumRodjenja,Adresa,Tip")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Korisnici.Add(korisnik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: Korisnik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KorisnikId,KorisnickoIme,Email,Lozinka,Ime,Prezime,DatumRodjenja,Adresa,Tip")] Korisnik korisnik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: Korisnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: Korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Korisnik korisnik = db.Korisnici.Find(id);
            db.Korisnici.Remove(korisnik);
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

        public ActionResult Profil()
        {
            //samo ako je prijavljen moci ce da menja profil
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if (korisnik == null || korisnik.KorisnickoIme == "")
            {
                //idi da se prijavis
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            //vju da menja profil
            return View(korisnik);
        }

        [HttpPost]
        public ActionResult IzmeniProfil(string email,string lozinka,string ime,string prezime,DateTime datumRodjenja,
            string adresa, string korisnickoIme, string imgPath)
        {
            //samo ako je prijavljen moci ce da menja profil
            Korisnik korr = (Korisnik)Session["korisnik"];
            if (korr == null || korr.KorisnickoIme == "")
            {
                //idi da se prijavis
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }


            Korisnik korisnik = db.Korisnici.Where(kor => kor.KorisnickoIme == korisnickoIme).FirstOrDefault();
            korisnik.Email = email;
            korisnik.Lozinka = lozinka;
            korisnik.Ime = ime;
            korisnik.Prezime = prezime;
            korisnik.DatumRodjenja = datumRodjenja;
            korisnik.Adresa = adresa;
            korisnik.ImagePath = imgPath;

            db.SaveChanges();

            ViewBag.Message = "Uspesno ste azurirali profil";
            return View("~/Views/Authentication/Provera.cshtml");        
        }


    }
}
