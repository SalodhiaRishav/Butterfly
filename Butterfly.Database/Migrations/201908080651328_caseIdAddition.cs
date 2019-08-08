namespace Butterfly.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class caseIdAddition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "CaseId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "CaseId");
        }
    }
}
