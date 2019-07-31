using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Configurations.Declaration
{
    using Butterfly.Database.Models.Declarations;
    using System.Data.Entity.ModelConfiguration;
    public class DropDownConfig : EntityTypeConfiguration<DropDown>
    {
        public DropDownConfig()
        {
            this.HasKey<Guid>(d => d.Id);
            this.Property(d => d.Key)
                .IsRequired();
            this.Property(d => d.Type)
                .IsRequired();
            this.Property(d => d.Value)
                .IsRequired();
        }
    }
}
