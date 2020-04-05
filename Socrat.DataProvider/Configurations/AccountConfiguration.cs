using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            ToTable("Account");
            HasKey(p => p.Id);

            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsRequired();
            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(100).IsOptional();
            Property(p => p.BankId).HasColumnName("Bank_Id").IsRequired();
            Property(p => p.Rs).HasColumnName("RS").HasMaxLength(20).IsOptional();
            Property(p => p.CurrencyId).HasColumnName("Currency_Id").IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(300).IsOptional();
            HasMany(e => e.Orders)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.AccountId);
        }
    }
}
