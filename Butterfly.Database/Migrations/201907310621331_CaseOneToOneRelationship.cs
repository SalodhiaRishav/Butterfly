namespace Butterfly.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CaseOneToOneRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaseInformations", "Id", "dbo.Cases");
            DropForeignKey("dbo.CaseStatus", "Id", "dbo.Cases");
            DropForeignKey("dbo.Clients", "Id", "dbo.Cases");
            DropForeignKey("dbo.Notes", "Id", "dbo.Cases");
            DropIndex("dbo.CaseInformations", new[] { "Id" });
            DropIndex("dbo.CaseStatus", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropIndex("dbo.Notes", new[] { "Id" });
            DropPrimaryKey("dbo.CaseInformations");
            DropPrimaryKey("dbo.CaseStatus");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Notes");
            AddColumn("dbo.CaseInformations", "CaseId", c => c.Int(nullable: false));
            AddColumn("dbo.CaseStatus", "CaseId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "CaseId", c => c.Int(nullable: false));
            AddColumn("dbo.Notes", "CaseId", c => c.Int(nullable: false));
            AlterColumn("dbo.CaseInformations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.CaseStatus", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Clients", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CaseInformations", "Id");
            AddPrimaryKey("dbo.CaseStatus", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.Notes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Notes");
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.CaseStatus");
            DropPrimaryKey("dbo.CaseInformations");
            AlterColumn("dbo.Notes", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CaseStatus", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CaseInformations", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Notes", "CaseId");
            DropColumn("dbo.Clients", "CaseId");
            DropColumn("dbo.CaseStatus", "CaseId");
            DropColumn("dbo.CaseInformations", "CaseId");
            AddPrimaryKey("dbo.Notes", "Id");
            AddPrimaryKey("dbo.Clients", "Id");
            AddPrimaryKey("dbo.CaseStatus", "Id");
            AddPrimaryKey("dbo.CaseInformations", "Id");
            CreateIndex("dbo.Notes", "Id");
            CreateIndex("dbo.Clients", "Id");
            CreateIndex("dbo.CaseStatus", "Id");
            CreateIndex("dbo.CaseInformations", "Id");
            AddForeignKey("dbo.Notes", "Id", "dbo.Cases", "Id");
            AddForeignKey("dbo.Clients", "Id", "dbo.Cases", "Id");
            AddForeignKey("dbo.CaseStatus", "Id", "dbo.Cases", "Id");
            AddForeignKey("dbo.CaseInformations", "Id", "dbo.Cases", "Id");
        }
    }
}
