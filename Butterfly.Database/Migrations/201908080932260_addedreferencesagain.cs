namespace Butterfly.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreferencesagain : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReferenceTables");
            AddColumn("dbo.ReferenceTables", "ReferenceId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReferenceTables", "ReferenceId");
            DropColumn("dbo.ReferenceTables", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReferenceTables", "Id", c => c.Guid(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReferenceTables");
            DropColumn("dbo.ReferenceTables", "ReferenceId");
            AddPrimaryKey("dbo.ReferenceTables", "Id");
        }
    }
}
