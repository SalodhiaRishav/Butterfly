namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    class CaseReferenceConfigurations:EntityTypeConfiguration<CaseReference>
    {
        public CaseReferenceConfigurations()
        {
            this.HasKey<int>(caseReference => caseReference.Id);
            this.Property(caseReference => caseReference.Identity)
                .HasMaxLength(50);
            this.Property(caseReference => caseReference.Comment)
                .HasMaxLength(50);
        }
    }
}
