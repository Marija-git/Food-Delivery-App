namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class slika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Korisniks", "ImagePath");
        }
    }
}
