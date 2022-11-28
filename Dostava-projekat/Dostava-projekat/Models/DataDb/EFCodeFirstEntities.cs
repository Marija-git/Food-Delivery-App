using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Dostava_projekat.Models.DataDb
{
    public class EFCodeFirstEntities:DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<KorisnikKojiCekaZahtev> KorisniciNaCekanjuOdobrenjaZahteva { get; set; }

        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Porudzbina> Porudzbine { get; set; }

        public DbSet<PoruceniProizvodi> Poruceni { get; set; }

      

        
    }
}