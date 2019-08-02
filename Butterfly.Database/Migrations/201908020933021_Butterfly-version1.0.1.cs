namespace Butterfly.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Butterflyversion101 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaseInformations", "Description", c => c.String(maxLength: 200));
            DropColumn("dbo.CaseInformations", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CaseInformations", "Desription", c => c.String(maxLength: 200));
            DropColumn("dbo.CaseInformations", "Description");
        }
    }
}
