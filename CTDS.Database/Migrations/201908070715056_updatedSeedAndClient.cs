namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedSeedAndClient : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Country", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Country", c => c.Int(nullable: false));
        }
    }
}
