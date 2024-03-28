# Veb-2
Food delivery App / Aplikacija za dostavu hrane
Cilj: Napredne veb tehnologije (Entity Framework,MS SQL Server).
Korisnici aplikacije su: Administrator, Dostavljač i Potrošač. U zavisnosti od uloge su implementirane odredjene funkcionalnosti.

__Opis projekta__

Funkcionalnosti sistema:

__Neprijavljeni korisnik__
    -vidi početnu stranicu na kojoj može da se uloguje(ako je registrovan) ili da izvrši registraciju na sistem
    -login se vrši preko email i lozinke
    -registracija se vrši unosom korisničkog imena,email,lozinike,ime,prezime,datum rođenja,adrese,tip korisnika(admin,dostavljač,potrošač),slika(opciono). Lozinka se unosi u dva polja da bi se otežalo pravljenje grešaka prilikom odabira nove.
    -slika se čuva na serveru
    
__Autentifikacija,autorizacija__

__Prijavljeni korisnik:__
      -Može da ažurira lične podatke na stranici za prikaz profila
      -Nakon uspešnog logovanja ide na početnu stranu koja obuhvata određene elemente u zavisnosti od uloge.
      
__Administrator:__
      -Nakon registracije korisnika, administrator treba da potvrdi registraciju/da uradi verifikaciju registracije za dostavljače.
         -Ima mogućnost pregledanja podataka pri čemu određeni zahtev može da prihvati ili odbije.Nakon prihvatanja, profil postaje aktivan.
         -Za obične potrošače nije potrebna verifikacija.
      -Nakon logovanja ima sledeće opcije: Profil,Prikaz svih porudžbina, dodavanje novih proizvoda,verifikacija korisnika(onih što podneli zahtev prilikom registracije da budu dostavljači)
      -Administrator vidi listu dostavljača kao i njihov status, može da im odobri ili odbije status i vidi koji su odobreni.
      -Administrator ima uvid u sve porudžbine koje su započete (i završene) kao i njihov status. Za porudžbine u toku nije potrebno odbrojavanje do dostave.
      -Admin dodaje nove proizvode koje prodaje restoran. Proizvod treba da ima ime, cenu i sastojke.
      
__Dostavljač:__
      -Korisnik/potencijalni dostavljač ima indikaciju o statusu proca verifikacije na svom profilu (zahtev se procesira,prihvaćen,odbijen).
      -Nakon logovanja ima sledeće opcije: Profil, prikaz novih porudzbina,dosadašnje poružbine,trenutnu porudžbinu
      -Dostavljač vidi spisak novih porudžbina koje čekaju dostavljača i može da prihvati porudžbine na čekanju
      -Treba sprečiti da dostavljač preuzme više narudžbina istovremeno.
      -Dostavljač može da vidi svoje prethodne porudžbine.
      
__Potrošač:__
      -Nakon logovanja ima sledeće opcije: Profil
      -Kreira novu poruzbinu sa poljima: količina,adresa dostave, komentari,cena.
      -Može poručiti jedan ili više proizvoda
      -Cena se računa po tome šta poručuje i količini plus cena dostave koja je uvek ista.
      -Kada potrošač poruči dostavu, čeka dostavljača da prihvati porudžbinu
      -Potrošač može da vidi listu svojih prethodnih porudžbina

__Tehnologije__ : ASP.NET MVC, MS SQL Server, C#, HTML, CSS, Razor, EntityFramework

__Opis rešenja__
Autentifikacija: Prilikom logovanja vrši se provera unete vrednosti sa vrednošću iz baze.
Korišćen je session objekat za čuvanje podataka o ulogovanom korisniku. Prilikom logovanja, u Session je dodat korisnik.
Autorizacija je rađena preko jednostvane provere uslova u zavisnosti od uloge korinika (tipa korisnika).
Za rad sa bazom korišćen EF-CodeFirst pristup.
   -Podacima se pristupa preko LINQ izraza.
   -Klasa dbContext se mapira na bazu,a DbSet na tabele u bazi.
   -Prilikom dodavanje nove klase (npr. Korsinik), ažurira se i baza korišćenjem migracija.
   
__Ostalo za doradu/Poboljšanja__

   1.štoperica (kada dostavljac prihvati dostavu kreće odbrojavanje na ekranu potrošača i dostavljača)
 
   2.email (slanje email-a dostavljaču kao obaveštenje o tome da li je prihvaćen za rad)
 
   3.registracija putem društvene mreže

   4.Prikaz trenutne porudzbine kod potrošača.

   5.Važno je da više istovremenih korisnika aplikacije, ne može da radi nad istim elementom u istom vremenskom periodu.

   6.Poboljšanje vizuelnog izgleda aplikacije.

   7.Prilikom promene slike se ne vidi odmah promena nego je potrebno ulogovati se ponovo. 

   8.Uspostava relacija između tabela u bazi.

