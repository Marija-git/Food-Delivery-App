namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KomentarNijeObavezan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PoruceniProizvodis", "Komentar", c => c.String());
            AlterColumn("dbo.Porudzbinas", "Komentar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Porudzbinas", "Komentar", c => c.String(nullable: false));
            AlterColumn("dbo.PoruceniProizvodis", "Komentar", c => c.String(nullable: false));
        }
    }
}
