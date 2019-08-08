
namespace Butterfly.Database.Context
{
    using System.Data.Entity;

    using Butterfly.Database.Models.Declarations;
    using Butterfly.Database.Configurations.Declaration;
    using Butterfly.Database.Models.CaseManagement;
    using Butterfly.Database.Configurations.CaseManagement;

    public class ButterflyContext : DbContext
    {
        public ButterflyContext() : base("ButterflyContext")
        {

        }
        public DbSet<Declaration> Declaration { get; set; }

        public DbSet<DropDown> DropDown { get; set; }
        public DbSet<Case> Case { get; set; }
        public DbSet<CaseInformation> CaseInformation {get; set;}

        public DbSet<CaseReference> CaseReference { get; set; }

        public DbSet<CaseStatus> CaseStatus { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<ReferenceTable> Reference { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure Column
            modelBuilder.Configurations.Add(new DeclarationConfig());
            modelBuilder.Configurations.Add(new DropDownConfig());
            modelBuilder.Configurations.Add(new CaseConfigurations());
            modelBuilder.Configurations.Add(new CaseInformationConfigurations());
            modelBuilder.Configurations.Add(new CaseReferenceConfigurations());
            modelBuilder.Configurations.Add(new CaseStatusConfigurations());
            modelBuilder.Configurations.Add(new ClientConfigurations());
            modelBuilder.Configurations.Add(new NotesConfigurations());
            modelBuilder.Configurations.Add(new ReferenceConfig());


        }

    }
}
