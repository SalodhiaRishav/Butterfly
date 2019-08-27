namespace CTDS.Database.Configurations.MasterData
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using CTDS.Database.Models.Common;

    public class MasterDataConfig : EntityTypeConfiguration<MasterData>
    {
        public MasterDataConfig()
        {
            this.HasKey<Guid>(d => d.Id);
            this.Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.Key)
                .IsRequired();
            this.Property(d => d.Type)
                .IsRequired();
            this.Property(d => d.Value)
                .IsRequired();
        }
    }
}
