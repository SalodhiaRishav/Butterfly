using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Configurations.Declaration
{
    using Butterfly.Database.Models.Declarations;
    using System.Data.Entity.ModelConfiguration;

    public class DeclarationConfig : EntityTypeConfiguration<Declaration>
    {
        public DeclarationConfig()
        {
            this.HasKey<int>(d => d.DeclarationId);
            this.Property(d => d.DeclarantCountry)
                .IsRequired();
            this.Property(d => d.Amount)
                .IsRequired();
            this.Property(d => d.ConsigneeAddress1)
                .IsRequired();
            this.Property(d => d.ConsigneeAddress2)
                .IsRequired();
            this.Property(d => d.ConsigneeCity)
                .IsRequired();
            this.Property(d => d.ConsigneeCountry)
                .IsRequired();
            this.Property(d => d.ConsigneeName)
                .IsRequired();
            this.Property(d => d.ConsigneeOrganisationNumber)
                .IsRequired();
            this.Property(d => d.ConsigneePostalCode)
                .IsRequired();
            this.Property(d => d.ConsignorCity)
                .IsRequired();
            this.Property(d => d.ConsignorCountry)
                .IsRequired();
            this.Property(d => d.InvoiceDate)
                .IsRequired()
                .HasColumnType("datetime2");

        }

    }
}
