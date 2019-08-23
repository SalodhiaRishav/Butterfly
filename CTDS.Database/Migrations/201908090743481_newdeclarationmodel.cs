namespace CTDS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdeclarationmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Declarations", "ConsigneeName", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneeOrganisationNumber", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneeAddress1", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneeAddress2", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneePostalCode", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneeCity", c => c.String());
            AlterColumn("dbo.Declarations", "ConsigneeCountry", c => c.String());
            AlterColumn("dbo.Declarations", "ConsignorCity", c => c.String());
            AlterColumn("dbo.Declarations", "ConsignorCountry", c => c.String());
            AlterColumn("dbo.Declarations", "DeclarantCountry", c => c.String());
            AlterColumn("dbo.Declarations", "Amount", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Declarations", "Amount", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "DeclarantCountry", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsignorCountry", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsignorCity", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeCountry", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeCity", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneePostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeAddress2", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeAddress1", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeOrganisationNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Declarations", "ConsigneeName", c => c.String(nullable: false));
        }
    }
}
