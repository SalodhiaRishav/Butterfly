namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    public class CaseConfigurations : EntityTypeConfiguration<Case>
    {
        public CaseConfigurations()
        {
            this.HasKey(c => c.Id);
            this.Property(c=>c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(c => c.CaseReferences)
                .WithRequired(caseReference => caseReference.Case)
                .HasForeignKey(caseReference => caseReference.CaseId);
        }
    }
}
