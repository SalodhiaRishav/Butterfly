namespace CTDS.Database.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addedstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Declarations", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Declarations", "Status");
        }
    }
}
