namespace Wiki.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Date = c.DateTime(nullable: false),
                        Result = c.String(),
                        IsSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Records");
        }
    }
}
