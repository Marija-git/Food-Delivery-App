using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Dostava_projekat.Models;
using Dostava_projekat.Models.DataDb;
using System.Timers;


namespace Dostava_projekat.Controllers
{
    public class DostavljacController : Controller
    {
        private EFCodeFirstEntities db = new EFCodeFirstEntities();
        // GET: Dostavljac
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DostavljacPage()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if (korisnik == null || korisnik.KorisnickoIme == "")
            {
                ViewBag.Message = "You have to login as delivery person.";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            if (korisnik.Tip != "Dostavljac")
            {
                ViewBag.Message = "This is for delivery person only.";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            ViewBag.model = korisnik;
            return View(db.Porudzbine);
        }

        [HttpPost]
        public ActionResult Prihvati(int PorudzbinaId)
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];

            //spreciti da prihvati ako vec ima neku narudzbinu koja je zapoceta
            foreach (Porudzbina pp in db.Porudzbine)
            {
                if (pp.DostavljacKojiMePokupio == korisnik.KorisnickoIme && pp.Status == "ZAPOCETO")
                {
                    ViewBag.Message = "You already have a pending order.";
                    return View("~/Views/Authentication/Provera.cshtml");
                }
            }

            Porudzbina p = db.Porudzbine.Where(por => por.PorudzbinaId == PorudzbinaId).FirstOrDefault();
            p.Status = "ZAPOCETO";
            p.DostavljacKojiMePokupio = korisnik.KorisnickoIme;
            db.SaveChanges();
              
            ViewBag.Message = "You accepted the order succesfully.";
            return View("~/Views/Authentication/Provera.cshtml");

        }

         
        public ActionResult ProveraStatusa()
        {
            return View();
        }


        public ActionResult StatusVerifikacije(string email,string lozinka)
        {
                List<KorisnikKojiCekaZahtev> korisnici = db.KorisniciNaCekanjuOdobrenjaZahteva.ToList();
                KorisnikKojiCekaZahtev k = korisnici.Find(u => u.Email.Equals(email) && u.Lozinka.Equals(lozinka));
                if (k == null)
                {
                    ViewBag.Message = $"You have never applied!";
                    return View("~/Views/Authentication/Provera.cshtml");
                }

            string status = k.StatusZahteva.ToString();
                ViewBag.Message = $"Your status : {status}";
                return View("~/Views/Authentication/Provera.cshtml");
            
        }


        [HttpPost]
        public ActionResult IzvrsiNarudzbinu(int PorudzbinaId)
        {

            Porudzbina p = db.Porudzbine.Where(por => por.PorudzbinaId == PorudzbinaId).FirstOrDefault();
            p.Status = "ZAVRSENO";
            p.DostavljacKojiMePokupio = null;
            db.SaveChanges();

            ViewBag.Message = "Order is done.";
            return View("~/Views/Authentication/Provera.cshtml");
        }

    }
}