using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dostava_projekat.Models
{
    public class Proizvod
    {
        [Key]
        public int ProizvodId { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string ImeProizvoda { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public double CenaProizvoda { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        public string Sastojci { get; set; }
    }
}