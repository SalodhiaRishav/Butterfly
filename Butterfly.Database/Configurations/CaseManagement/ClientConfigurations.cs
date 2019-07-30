namespace Butterfly.Database.Configurations.CaseManagement
{
    using Butterfly.Database.Models.CaseManagement;
    using System.Data.Entity.ModelConfiguration;

    public class ClientConfigurations : EntityTypeConfiguration<Client>
    {
        public ClientConfigurations()
        {
            this.HasKey<int>(client => client.Id);

            this.Property(client => client.IdentifierType)
                .IsRequired();

            this.Property(client => client.ClientIdentifier)
                .IsRequired();

            this.Property(client => client.Name)
                .HasMaxLength(40);

            this.Property(client => client.Address)
                .HasMaxLength(200);

            this.Property(client => client.PostalCode)
                .HasMaxLength(50);

            this.Property(client => client.City)
                .HasMaxLength(50);

            this.Property(client => client.Email)
                .HasMaxLength(50);
        }
    }
}
