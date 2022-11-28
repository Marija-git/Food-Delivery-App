using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dostava_projekat.Models
{
    public class Porudzbina
    {
        [Key]
        public int PorudzbinaId { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string StaPorucuje { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public int Kolicina { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Adresa { get; set; }

       
        public string Komentar { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public double CenaPorudzbine { get; set; }

        public string Status { get; set; }
        
        public string DostavljacKojiMePokupio { get; set; }
    }
}