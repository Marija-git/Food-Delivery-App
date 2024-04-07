using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostava_projekat.Models;
using Dostava_projekat.Models.DataDb;

namespace Dostava_projekat.Controllers
{
    public class AdminController : Controller
    {
        private EFCodeFirstEntities db = new EFCodeFirstEntities();
        // GET: Admin
        public ActionResult Index()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if (korisnik == null || korisnik.KorisnickoIme == "")
            {
                ViewBag.Message = "Morate se ulogovati kao admin";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            if (korisnik.Tip != "Administrator")
            {
                ViewBag.Message = "Nemas prava za ovo jer nisi admin";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            List<KorisnikKojiCekaZahtev> pomocna = db.KorisniciNaCekanjuOdobrenjaZahteva.ToList();
            ViewBag.Message = pomocna;
            return View(db.KorisniciNaCekanjuOdobrenjaZahteva);
         
        }

        [HttpPost]
        public ActionResult PrihvatiZahtev(string KorisnickoIme)
        {
            //ViewBag.Message = $" ajde prikazi jebeni string koji si primio :::{KorisnickoIme}";
            //return View("~/Views/Authentication/Provera.cshtml");
            Korisnik k = new Korisnik();
            foreach (var item in db.KorisniciNaCekanjuOdobrenjaZahteva)
            {
                if (item.KorisnickoIme == KorisnickoIme)
                {
                    k.KorisnickoIme = item.KorisnickoIme;
                    k.Email = item.Email;
                    k.Lozinka = item.Lozinka;
                    k.Ime = item.Ime;
                    k.Prezime = item.Prezime;
                    k.DatumRodjenja = item.DatumRodjenja;
                    k.Adresa = item.Adresa;
                    k.Tip = item.Tip;

                }
            }
            foreach (var kk in db.Korisnici)
            {
                if (kk.KorisnickoIme == KorisnickoIme)
                {
                    ViewBag.Message = "Korisnik sa ovim korisnickim imenom vec postoji u bazi";
                    return View("~/Views/Authentication/Provera.cshtml");
                }
            }
            db.Korisnici.Add(k);

            //promeni status zahteva
            KorisnikKojiCekaZahtev kkcz = db.KorisniciNaCekanjuOdobrenjaZahteva.Where(x => x.KorisnickoIme == KorisnickoIme).FirstOrDefault();
            kkcz.StatusZahteva = "PRIHVACEN";


            db.SaveChanges();
            ViewBag.Message = "Korisnik je dodat u bazu registrovanih";
            return View("~/Views/Authentication/Provera.cshtml");

        }

        [HttpPost]
        public ActionResult OdbijZahtev(string KorisnickoIme)
        {
            KorisnikKojiCekaZahtev kkcz = db.KorisniciNaCekanjuOdobrenjaZahteva.Where(x => x.KorisnickoIme == KorisnickoIme).FirstOrDefault();
            kkcz.StatusZahteva = "ODBIJEN";
            db.SaveChanges();
            ViewBag.Message = "Odbili ste zahtev";
            return View("~/Views/Authentication/Provera.cshtml");
        }

        public ActionResult AdminPage()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if (korisnik == null || korisnik.KorisnickoIme == "")
            {
                ViewBag.Message = "Morate se ulogovati kao admin";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            if (korisnik.Tip != "Administrator")
            {
                ViewBag.Message = "Nemas prava za ovo jer nisi administrator";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }


            ViewBag.model = korisnik;
            ViewBag.proizvodi = db.Proizvodi;
            return View(db.Porudzbine);
        }

       [HttpPost]
       public ActionResult DodajProizvod()
       {          
           return View();
       }

        [HttpPost]
        public ActionResult DodavanjeProizvoda(string ImeProizvoda,int CenaProizvoda,string Sastojci)
        {
            foreach(Proizvod pp in db.Proizvodi)
            {
                if(pp.ImeProizvoda == ImeProizvoda)
                {
                    ViewBag.Message = $"Proizvod vec postoji";
                    return View("~/Views/Authentication/Provera.cshtml");
                }
            }

            Proizvod p = new Proizvod();
            p.ImeProizvoda = ImeProizvoda;
            p.CenaProizvoda = CenaProizvoda;
            p.Sastojci = Sastojci;
            db.Proizvodi.Add(p);
            db.SaveChanges();

            ViewBag.Message = $"Uspesno dodavanje proizvoda";
            return View("~/Views/Authentication/Provera.cshtml");
        }

    }
}