using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Database.Context
{
    using System.Data.Entity;
    using Butterfly.Database.Models.Declarations;
    using Butterfly.Database.Configurations.Declaration;
    public class ButterflyContext : DbContext
    {
        public ButterflyContext() : base("ButterflyContext")
        {

        }
        public DbSet<Declaration> Declaration { get; set; }

        public DbSet<DropDown> DropDown { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure Column
            modelBuilder.Configurations.Add(new DeclarationConfig());
            modelBuilder.Configurations.Add(new DropDownConfig());
         
        }

    }
}
