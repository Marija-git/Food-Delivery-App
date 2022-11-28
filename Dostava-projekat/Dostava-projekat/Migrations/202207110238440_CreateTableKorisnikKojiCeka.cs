namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableKorisnikKojiCeka : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KorisnikKojiCekaZahtevs",
                c => new
                {
                    KorisnikId = c.Int(nullable: false, identity: true),
                    KorisnickoIme = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Lozinka = c.String(nullable: false),
                    Ime = c.String(nullable: false),
                    Prezime = c.String(nullable: false),
                    DatumRodjenja = c.DateTime(nullable: false),
                    Adresa = c.String(nullable: false),
                    Tip = c.String(nullable: false),
                })
                .PrimaryKey(t => t.KorisnikId);

        }

        public override void Down()
        {
            DropTable("dbo.KorisnikKojiCekaZahtevs");
        }
    }
}
