using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dostava_projekat.Models
{
    public class KorisnikKojiCekaZahtev 
    {
        [Key]
        public int KorisnikId { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [DisplayName("Korisnicko Ime")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Lozinka { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public DateTime DatumRodjenja { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Tip { get; set; }

        public string StatusZahteva { get; set; }
    }
}