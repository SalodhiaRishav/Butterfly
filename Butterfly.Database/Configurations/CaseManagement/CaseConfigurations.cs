namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    public class CaseConfigurations : EntityTypeConfiguration<Case>
    {
        public CaseConfigurations()
        {
            this.HasKey<int>(c => c.Id);

            this.HasMany(c => c.CaseReferences)
                .WithRequired(caseReference => caseReference.Case)
                .HasForeignKey(caseReference => caseReference.CaseId);
        }
    }
}
