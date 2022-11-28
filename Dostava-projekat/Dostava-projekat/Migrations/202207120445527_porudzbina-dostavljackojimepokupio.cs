namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class porudzbinadostavljackojimepokupio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Porudzbinas", "DostavljacKojiMePokupio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Porudzbinas", "DostavljacKojiMePokupio");
        }
    }
}
