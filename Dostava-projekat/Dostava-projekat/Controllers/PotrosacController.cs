using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using Dostava_projekat.Models;
using Dostava_projekat.Models.DataDb;

namespace Dostava_projekat.Controllers
{
    public class PotrosacController : Controller
    {
        private EFCodeFirstEntities db = new EFCodeFirstEntities();
        // GET: Potrosac
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PotrosacPage()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            if (korisnik == null || korisnik.KorisnickoIme == "")
            {
                ViewBag.Message = "You have to login as customer.";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            if (korisnik.Tip != "Potrosac")
            {
                ViewBag.Message = "This is for customer only.";
                return View("~/Views/Authentication/LoginPocetna.cshtml");
            }

            ViewBag.model = korisnik;
            return View(db.Porudzbine);
        }

      
        public ActionResult Poruci()
        {
            Korisnik korisnik = (Korisnik)Session["korisnik"];
            ViewBag.model = korisnik;
            List<Proizvod> listaProizvoda = db.Proizvodi.ToList();
            ViewBag.Message = listaProizvoda;
            return View();
        }


        [HttpPost]
        public ActionResult KreirajPorudzbinu(string ImeProizvoda,int Kolicina,string Adresa,string Komentar)
        {
            PoruceniProizvodi pp = new PoruceniProizvodi();
            pp.NazivProizvoda = ImeProizvoda;
            pp.Kolicina = Kolicina;
            pp.Adresa = Adresa;
            pp.Komentar = Komentar;
            
            foreach(Proizvod p in db.Proizvodi)
            {
                if(p.ImeProizvoda == ImeProizvoda)
                {
                    pp.Cena = p.CenaProizvoda * Kolicina;
                }
            }
            db.Poruceni.Add(pp);
            db.SaveChanges();

            return View("PoruciJosORGotovo");

        }

        [HttpPost]
        public ActionResult ZavrsiPorudzbinu()
        {
            //kreiraj porudzbinu sada tako sto ces da spojis 
            Porudzbina porudzbina = new Porudzbina();
            List<PoruceniProizvodi> listaPorucenih = new List<PoruceniProizvodi>();
            foreach(PoruceniProizvodi pp in db.Poruceni)
            {
                listaPorucenih.Add(pp);
            }

            //1) sta porucuje
            List<string> listaSvihImenaProizvoda = new List<string>();
            foreach(PoruceniProizvodi ppp in listaPorucenih)
            {
                listaSvihImenaProizvoda.Add(ppp.NazivProizvoda);
            }
            foreach(string s in listaSvihImenaProizvoda)
            {
                porudzbina.StaPorucuje = string.Join(",", listaSvihImenaProizvoda);
            }


            //2) komentar
            List<string> sviKomentari = new List<string>();
            foreach(PoruceniProizvodi ppp in listaPorucenih)
            {
                sviKomentari.Add(ppp.Komentar);
            }
            foreach(string s in sviKomentari)
            {
                porudzbina.Komentar = string.Join(",", sviKomentari);
            }

            //3) cena porudzbine
            List<double> cene = new List<double>();
            foreach(PoruceniProizvodi ppp in listaPorucenih)
            {
                cene.Add(ppp.Cena);
            }
            foreach(double c in cene)
            {
                porudzbina.CenaPorudzbine += c; //saberi sve cene
            }
            porudzbina.CenaPorudzbine += 100; //dostava

            //5) kolicina
            List<int> kolicine = new List<int>();
            foreach(PoruceniProizvodi ppp in listaPorucenih)
            {
                kolicine.Add(ppp.Kolicina);
            }
            foreach(int k in kolicine)
            {
                porudzbina.Kolicina += k;
            }

            //5)adresa
            PoruceniProizvodi pom = new PoruceniProizvodi();
            pom = listaPorucenih[0];
            porudzbina.Adresa = pom.Adresa;

            //6)
            porudzbina.Status = "U TOKU";

            db.Porudzbine.Add(porudzbina);            
            foreach(PoruceniProizvodi poruceniProizvodi in db.Poruceni)
            {
                db.Poruceni.Remove(poruceniProizvodi);
            }
            db.SaveChanges();


            ViewBag.Message = $"Succesfully ordered!";
            return View("~/Views/Authentication/Provera.cshtml");
        }

       
    }
}