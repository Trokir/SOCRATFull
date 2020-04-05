using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class LegalEntityConfiguration : EntityTypeConfiguration<LegalEntity>
    {
        public LegalEntityConfiguration()
        {
            ToTable("LegalEntity");
            HasKey(p => p.Id);

            Property(p => p.CustomerId).HasColumnName("CustomerId").IsRequired();
            Property(p => p.Fullname).HasColumnName("Fullname").IsRequired();
            Property(p => p.Inn).HasColumnName("Inn").HasMaxLength(12).IsRequired();
            Property(p => p.Okpo).HasColumnName("Okpo").HasMaxLength(12).IsOptional();
            Property(p => p.Ogrn).HasColumnName("Ogrn").HasMaxLength(13).IsOptional();
            Property(p => p.Kpp).HasColumnName("Kpp").HasMaxLength(9).IsOptional();


            HasMany(e => e.Addresses)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
