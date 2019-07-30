namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    public class CaseConfigurations : EntityTypeConfiguration<Case>
    {
        public CaseConfigurations()
        {
            this.HasKey<int>(c => c.Id);

            this.HasOptional(c => c.Client)
                .WithRequired(client => client.Case);

            this.HasOptional(c => c.CaseInformation)
               .WithRequired(caseInformation => caseInformation.Case);

            this.HasOptional(c => c.Notes)
               .WithRequired(notes => notes.Case);

            this.HasOptional(c => c.CaseStatus)
              .WithRequired(caseStatus => caseStatus.Case);

            this.HasMany(c => c.CaseReferences)
                .WithRequired(caseReference => caseReference.Case)
                .HasForeignKey(caseReference => caseReference.CaseId);
        }
    }
}
