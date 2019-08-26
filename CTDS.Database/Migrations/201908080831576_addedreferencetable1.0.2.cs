namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreferencetable102 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReferenceTables");
            AlterColumn("dbo.ReferenceTables", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReferenceTables", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ReferenceTables");
            AlterColumn("dbo.ReferenceTables", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ReferenceTables", "Id");
        }
    }
}
