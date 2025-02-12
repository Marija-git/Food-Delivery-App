﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dostava_projekat.Models;
using Dostava_projekat.Models.DataDb;

namespace Dostava_projekat.Controllers
{
    public class AuthenticationController : Controller
    {
        private EFCodeFirstEntities db = new EFCodeFirstEntities();
        // GET: Authentication
        public ActionResult Index()
        {
            return View("LoginPocetna");
        }

        [HttpPost]
        public ActionResult Register()
        {
            Korisnik korisnik = new Korisnik();
            Session["korisnik"] = korisnik;
            return View(korisnik);
        }

        [HttpPost]
        public ActionResult RegistracijaKorisnika(KorisnikKojiCekaZahtev korisnik, string nekalozinka)
        {
            List<Korisnik> korisnici = db.Korisnici.ToList();
            foreach (Korisnik kor in korisnici)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    ViewBag.Message = $"User {korisnik.KorisnickoIme} already exists!";
                    return View("RegisterError");
                }
            }

            if (korisnik.KorisnickoIme == null || korisnik.Lozinka == null || korisnik.Ime == null
                 || korisnik.Prezime==null || korisnik.Adresa== null || korisnik.DatumRodjenja== null
                 ||korisnik.Tip==null || korisnik.Email == null)
            {
                ViewBag.Message = "All fields are required!";
                return View("RegisterError");
            }

            if(korisnik.Lozinka != nekalozinka)
            {
                ViewBag.Message = "Password error!";
                return View("RegisterError");
            }
            
            if(korisnik.Tip != "Potrosac" && korisnik.Tip != "Administrator" && korisnik.Tip != "Dostavljac")
            {
                ViewBag.Message = "Enter valid type.";
                return View("RegisterError");
            }

            if (korisnik.Tip == "Dostavljac")
            {
                korisnik.StatusZahteva = "U PROCESU";
                db.KorisniciNaCekanjuOdobrenjaZahteva.Add(korisnik);
                db.SaveChanges();
                ViewBag.Message = "Your register request is sucessfully sent to admin.";
                return View("Provera");
            }

            Korisnik k = new Korisnik();
           // k.KorisnikId = korisnik.KorisnikId;
            k.KorisnickoIme = korisnik.KorisnickoIme;
            k.Email = korisnik.Email;
            k.Lozinka = korisnik.Lozinka;
            k.Ime = korisnik.Ime;
            k.Prezime = korisnik.Prezime;
            k.DatumRodjenja = korisnik.DatumRodjenja;
            k.Adresa = korisnik.Adresa;
            k.Tip = korisnik.Tip;


            db.Korisnici.Add(k);
            db.SaveChanges();
            ViewBag.Message = "Successfully signed up.";
            return View("Provera");
        }

        [HttpPost]
        public ActionResult Login(string email,string lozinka)
        {
            List<Korisnik> korisnici = db.Korisnici.ToList();
            Korisnik k = korisnici.Find(u => u.Email.Equals(email) && u.Lozinka.Equals(lozinka));
            if (k == null)
            {
                ViewBag.Message = $"User with this email and password doesn't exist!";
                return View("LoginPocetna");
            }
            Session["korisnik"] = k;
           

            if(k.Tip == "Administrator")
            {
                return RedirectToAction("AdminPage","Admin"); //izbrisi sa navbar-a
            }
            else if(k.Tip == "Potrosac")
            {
                return RedirectToAction("PotrosacPage", "Potrosac");
            }
            else
            {
                 return RedirectToAction("DostavljacPage", "Dostavljac"); 
            }

        }

        public ActionResult LogOut()
        {
            Session["korisnik"] = null; //obrisemo sve sa sesije
            ViewBag.Message = $"Logged out";
            return View("LoginPocetna");
        }

        
    }
}