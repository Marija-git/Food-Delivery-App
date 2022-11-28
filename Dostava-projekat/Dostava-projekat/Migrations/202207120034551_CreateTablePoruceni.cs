namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePoruceni : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoruceniProizvodis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NazivProizvoda = c.String(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Adresa = c.String(nullable: false),
                        Komentar = c.String(nullable: false),
                        Cena = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PoruceniProizvodis");
        }
    }
}
