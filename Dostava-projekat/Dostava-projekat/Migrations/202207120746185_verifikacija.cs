namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verifikacija : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KorisnikKojiCekaZahtevs", "StatusZahteva", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KorisnikKojiCekaZahtevs", "StatusZahteva");
        }
    }
}
