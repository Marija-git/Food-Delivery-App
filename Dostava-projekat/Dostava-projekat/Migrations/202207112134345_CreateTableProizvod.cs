namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProizvod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        ProizvodId = c.Int(nullable: false, identity: true),
                        ImeProizvoda = c.String(nullable: false),
                        CenaProizvoda = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProizvodId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proizvods");
        }
    }
}
