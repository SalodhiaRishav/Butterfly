namespace Butterfly.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class butterflyversion100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CaseInformations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Desription = c.String(maxLength: 200),
                        MessageFromClient = c.String(maxLength: 200),
                        Priority = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.CaseReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Identity = c.String(maxLength: 50),
                        Comment = c.String(maxLength: 50),
                        CaseId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.CaseId, cascadeDelete: true)
                .Index(t => t.CaseId);
            
            CreateTable(
                "dbo.CaseStatus",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClientIdentifier = c.String(nullable: false),
                        IdentifierType = c.Int(nullable: false),
                        Name = c.String(maxLength: 40),
                        Address = c.String(maxLength: 200),
                        PostalCode = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Country = c.Int(nullable: false),
                        Email = c.String(maxLength: 50),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NotesByCpa = c.String(maxLength: 200),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cases", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Declarations",
                c => new
                    {
                        DeclarationId = c.Int(nullable: false, identity: true),
                        ConsigneeName = c.String(nullable: false),
                        ConsigneeOrganisationNumber = c.String(nullable: false),
                        ConsigneeAddress1 = c.String(nullable: false),
                        ConsigneeAddress2 = c.String(nullable: false),
                        ConsigneePostalCode = c.String(nullable: false),
                        ConsigneeCity = c.String(nullable: false),
                        ConsigneeCountry = c.Int(nullable: false),
                        CustomCreditNumber = c.String(),
                        DefferedPayment = c.Int(nullable: false),
                        ConsignorName = c.String(),
                        ConsignorAddress1 = c.String(),
                        ConsignorAddress2 = c.String(),
                        ConsignorPostalCode = c.String(),
                        ConsignorCity = c.String(nullable: false),
                        ConsignorCountry = c.String(nullable: false),
                        DeclarantName = c.String(),
                        DeclarantOrganisationNumber = c.String(),
                        DeclarantAddress1 = c.String(),
                        DeclarantAddress2 = c.String(),
                        DeclarantPostalCode = c.String(),
                        DeclarantCity = c.String(),
                        DeclarantCountry = c.Int(nullable: false),
                        ContactPerson = c.String(),
                        MessageName = c.String(),
                        DeclarationType1 = c.String(),
                        DeclarationType2 = c.String(),
                        TermsOfDelivery = c.String(),
                        DeliveryPlace = c.String(),
                        CountryOfDispatch = c.String(),
                        NationalityOfTransport = c.String(),
                        ModeOfTransport = c.String(),
                        LocationOfGoods = c.String(),
                        SupervisingCustomOffice = c.String(),
                        NatureOfTransaction = c.String(),
                        Reference = c.String(),
                        InvoiceDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Type = c.String(),
                        Freight = c.String(),
                        Amount = c.String(nullable: false),
                        Currency = c.String(),
                        Rate = c.String(),
                    })
                .PrimaryKey(t => t.DeclarationId);
            
            CreateTable(
                "dbo.DropDowns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Key = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Id", "dbo.Cases");
            DropForeignKey("dbo.Clients", "Id", "dbo.Cases");
            DropForeignKey("dbo.CaseStatus", "Id", "dbo.Cases");
            DropForeignKey("dbo.CaseReferences", "CaseId", "dbo.Cases");
            DropForeignKey("dbo.CaseInformations", "Id", "dbo.Cases");
            DropIndex("dbo.Notes", new[] { "Id" });
            DropIndex("dbo.Clients", new[] { "Id" });
            DropIndex("dbo.CaseStatus", new[] { "Id" });
            DropIndex("dbo.CaseReferences", new[] { "CaseId" });
            DropIndex("dbo.CaseInformations", new[] { "Id" });
            DropTable("dbo.DropDowns");
            DropTable("dbo.Declarations");
            DropTable("dbo.Notes");
            DropTable("dbo.Clients");
            DropTable("dbo.CaseStatus");
            DropTable("dbo.CaseReferences");
            DropTable("dbo.CaseInformations");
            DropTable("dbo.Cases");
        }
    }
}
