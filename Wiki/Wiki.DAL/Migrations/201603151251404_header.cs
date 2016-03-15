namespace Wiki.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class header : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Header", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Header");
        }
    }
}
