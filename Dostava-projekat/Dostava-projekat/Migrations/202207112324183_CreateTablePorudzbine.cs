namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePorudzbine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Porudzbinas",
                c => new
                    {
                        PorudzbinaId = c.Int(nullable: false, identity: true),
                        StaPorucuje = c.String(nullable: false),
                        Kolicina = c.Int(nullable: false),
                        Adresa = c.String(nullable: false),
                        Komentar = c.String(nullable: false),
                        CenaPorudzbine = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PorudzbinaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Porudzbinas");
        }
    }
}
