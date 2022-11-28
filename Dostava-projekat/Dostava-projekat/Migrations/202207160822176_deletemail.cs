namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletemail : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Mails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mails",
                c => new
                    {
                        MailId = c.Int(nullable: false, identity: true),
                        Send_To_Email = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.MailId);
            
        }
    }
}
