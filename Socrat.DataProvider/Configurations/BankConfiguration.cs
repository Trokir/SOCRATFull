using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class BankConfiguration : EntityTypeConfiguration<Bank>
    {
        public BankConfiguration()
        {
            ToTable("Bank");
            HasKey(p => p.Id);

            Property(p => p.Bik).HasColumnName("Bik").HasMaxLength(9).IsOptional();
            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(30).IsOptional();
            Property(p => p.Filial).HasColumnName("Filial").HasMaxLength(200).IsOptional();
            Property(p => p.Ks).HasColumnName("KS").HasMaxLength(20).IsOptional();
            Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(12).IsOptional();
            Property(p => p.Comment).HasColumnName("Coment").HasMaxLength(100).IsOptional();
            Property(p => p.ShortName).HasColumnName("NameShort").HasMaxLength(30).IsOptional();
            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();

            HasMany(e => e.Accounts)
                .WithRequired(e => e.Bank)
                .HasForeignKey(e => e.BankId);
        }
    }
}
