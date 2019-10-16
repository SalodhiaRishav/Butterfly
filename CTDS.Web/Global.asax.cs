namespace CTDS.Web
{
    using System;
    using System.Data.Entity.Migrations;
    using CTDS.Database.Migrations;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();
        }
    }
}