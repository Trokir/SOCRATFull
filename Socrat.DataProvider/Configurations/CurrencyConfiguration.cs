using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            ToTable("Currency");
            HasKey(p => p.Id);

            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(10).IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(50).IsOptional();

            HasMany(e => e.Accounts)
                .WithOptional(e => e.Currency)
                .HasForeignKey(e => e.CurrencyId);

            HasMany(e => e.Customers)
                .WithOptional(e => e.Currency)
                .HasForeignKey(e => e.CurrencyId);
        }
    }
}
