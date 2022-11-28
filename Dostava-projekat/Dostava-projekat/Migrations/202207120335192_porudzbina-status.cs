namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class porudzbinastatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Porudzbinas", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Porudzbinas", "Status");
        }
    }
}
