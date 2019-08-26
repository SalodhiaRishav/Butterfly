namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedreferencetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReferenceTables",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Type = c.String(),
                        InvoiceDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Reference = c.String(),
                        DeclarationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Declarations", t => t.DeclarationId, cascadeDelete: true)
                .Index(t => t.DeclarationId);
            
            AddColumn("dbo.Declarations", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Declarations", "Reference");
            DropColumn("dbo.Declarations", "InvoiceDate");
            DropColumn("dbo.Declarations", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Declarations", "Type", c => c.String());
            AddColumn("dbo.Declarations", "InvoiceDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Declarations", "Reference", c => c.String());
            DropForeignKey("dbo.ReferenceTables", "DeclarationId", "dbo.Declarations");
            DropIndex("dbo.ReferenceTables", new[] { "DeclarationId" });
            DropColumn("dbo.Declarations", "CreatedOn");
            DropTable("dbo.ReferenceTables");
        }
    }
}
