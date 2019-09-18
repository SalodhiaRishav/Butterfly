namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tempIDGenerationOff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaseReferences", "CaseId", "dbo.Cases");
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Cases", "Id");
            AddForeignKey("dbo.CaseReferences", "CaseId", "dbo.Cases", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaseReferences", "CaseId", "dbo.Cases");
            DropPrimaryKey("dbo.Cases");
            AlterColumn("dbo.Cases", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cases", "Id");
            AddForeignKey("dbo.CaseReferences", "CaseId", "dbo.Cases", "Id", cascadeDelete: true);
        }
    }
}
