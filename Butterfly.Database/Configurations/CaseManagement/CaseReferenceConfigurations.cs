namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    class CaseReferenceConfigurations :EntityTypeConfiguration<CaseReference>
    {
        public CaseReferenceConfigurations()
        {
            this.HasKey(caseReference => caseReference.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(caseReference => caseReference.Identity)
                .HasMaxLength(50);
            this.Property(caseReference => caseReference.Comment)
                .HasMaxLength(50);
        }
    }
}
