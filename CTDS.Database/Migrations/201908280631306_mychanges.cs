namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mychanges : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.DropDowns");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DropDowns",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Key = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
