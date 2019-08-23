using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTDS.Database.Configurations.Declaration
{
    using CTDS.Database.Models.Declarations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

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

        }

    }
}
