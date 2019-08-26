namespace CTDS.Database.Configurations.CaseManagement
{
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;

    using CTDS.Database.Models.CaseManagement;
   
    class CaseStatusConfigurations : EntityTypeConfiguration<CaseStatus>
    {
        public CaseStatusConfigurations()
        {
            this.HasKey(caseStatus=>caseStatus.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
