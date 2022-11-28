using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dostava_projekat.Models
{
    public class PoruceniProizvodi
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string NazivProizvoda { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public string Adresa { get; set; }
      
        public string Komentar { get; set; }
        [Required(ErrorMessage = "Obavezno polje")]
        public double Cena { get; set; }
    }
}