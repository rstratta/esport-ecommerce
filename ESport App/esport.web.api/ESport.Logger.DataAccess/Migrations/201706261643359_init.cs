namespace ESport.Logger.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Action = c.String(),
                        LoggerDate = c.DateTime(nullable: false),
                        UserId = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
