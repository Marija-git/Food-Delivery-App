namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SastojciKolona : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Proizvods", "Sastojci", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Proizvods", "Sastojci");
        }
    }
}
