using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            ToTable("Country");
            HasKey(p => p.Id);

            Property(p => p.AliasName).HasColumnName("NameAlias").HasMaxLength(20).IsOptional();
            Property(p => p.ShortName).HasColumnName("NameShort").HasMaxLength(30).IsOptional();
            Property(p => p.FullName).HasColumnName("NameFull").HasMaxLength(150).IsOptional();

            HasMany(e => e.Addresses)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryId);

            HasMany(e => e.Customers)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryId);
        }
    }
}
