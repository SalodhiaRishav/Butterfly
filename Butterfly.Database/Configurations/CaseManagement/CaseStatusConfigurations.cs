namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    class CaseStatusConfigurations : EntityTypeConfiguration<CaseStatus>
    {
        public CaseStatusConfigurations()
        {
            this.HasKey<int>(caseStatus=>caseStatus.Id);
        }
    }
}
