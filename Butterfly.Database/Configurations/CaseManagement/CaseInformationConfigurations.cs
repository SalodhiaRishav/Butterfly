namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    class CaseInformationConfigurations : EntityTypeConfiguration<CaseInformation>
    {
        public CaseInformationConfigurations()
        {
            this.HasKey<int>(caseInformation => caseInformation.Id);

            this.Property(caseInformation => caseInformation.Desription)
                .HasMaxLength(200);

            this.Property(caseInformation => caseInformation.MessageFromClient)
                .HasMaxLength(200);
        }
    }
}
