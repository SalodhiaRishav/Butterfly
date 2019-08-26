namespace CTDS.Database.Configurations.CaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    using CTDS.Database.Models.CaseManagement;
    

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
