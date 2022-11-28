namespace Dostava_projekat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createTableMail : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.Mails");
        }
    }
}
