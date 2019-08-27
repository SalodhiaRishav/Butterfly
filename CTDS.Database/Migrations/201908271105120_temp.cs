namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class temp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MasterDatas",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Key = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MasterDatas");
        }
    }
}
