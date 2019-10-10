namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDeclarationId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Declarations", "DecId", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Declarations", "DecId");
        }
    }
}
