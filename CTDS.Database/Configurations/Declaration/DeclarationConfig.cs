namespace CTDS.Database.Configurations.Declaration
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using CTDS.Database.Models.Declarations;
    

    public class DeclarationConfig : EntityTypeConfiguration<Declaration>
    {
        public DeclarationConfig()
        {
            this.HasKey<Guid>(d => d.DeclarationId);
            this.Property(d => d.DeclarationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(d => d.CreatedOn)
                .IsRequired()
                .HasColumnType("datetime2");
            this.HasMany<ReferenceTable>(d => d.References)
                .WithRequired()
                .HasForeignKey<Guid>(r => r.DeclarationId);
            this.Property(d => d.DecId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }

    }
}
