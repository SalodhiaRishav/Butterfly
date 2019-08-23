namespace CTDS.Database.Configurations.CaseManagement
{
    using CTDS.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    class CaseInformationConfigurations : EntityTypeConfiguration<CaseInformation>
    {
        public CaseInformationConfigurations()
        {
            this.HasKey(caseInformation => caseInformation.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(caseInformation => caseInformation.Description)
                .HasMaxLength(200);

            this.Property(caseInformation => caseInformation.MessageFromClient)
                .HasMaxLength(200);
        }
    }
}
