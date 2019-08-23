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

    public class ReferenceConfig : EntityTypeConfiguration<ReferenceTable>
    {
        public ReferenceConfig()
        {
            this.HasKey<Guid>(r => r.ReferenceId);
            this.Property(r => r.ReferenceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(d => d.InvoiceDate)
                .IsRequired()
                .HasColumnType("datetime2");
            this.Property(d => d.DeclarationId)
                .IsRequired();
            this.Property(d => d.Reference)
                .IsRequired();
        }
    }
}
