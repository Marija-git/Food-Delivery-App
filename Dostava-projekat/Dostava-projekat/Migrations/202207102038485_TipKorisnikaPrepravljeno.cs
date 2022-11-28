namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipKorisnikaPrepravljeno : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Korisniks", "Tip", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Korisniks", "Tip", c => c.Int(nullable: false));
        }
    }
}
