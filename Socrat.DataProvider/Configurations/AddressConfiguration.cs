using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("address");
            HasKey(p => p.Id);

            Property(p => p.CountryId).HasColumnName("Country_Id").IsOptional();
            Property(p => p.ZipCode).HasColumnName("ZipCode").HasMaxLength(30).IsOptional();
            Property(p => p.ValueStr).HasColumnName("ValueStr").HasMaxLength(500).IsOptional();
            Property(p => p.IsProduction).HasColumnName("IsProduction").HasColumnType("bit").IsOptional();

            HasMany(e => e.AddressContacts)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.AddressItems)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.Banks)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.ContractAddresses)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.Customers)
                .WithOptional(e => e.LegalAddress)
                .HasForeignKey(e => e.LegalAddressId);

            HasMany(e => e.Customers1)
                .WithOptional(e => e.ActualAddress)
                .HasForeignKey(e => e.ActualAddressId);

            HasMany(e => e.CustomerAddresses)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.Divisions)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Address)
                .HasForeignKey(e => e.AddressId)
                .WillCascadeOnDelete(true);
        }
    }
}
