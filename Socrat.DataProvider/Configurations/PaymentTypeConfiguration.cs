using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PaymentTypeConfiguration : EntityTypeConfiguration<PaymentType>
    {
        public PaymentTypeConfiguration()
        {
            ToTable("PaymentType");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.PaymentTypeNum).HasColumnName("PaymentTypeNum").IsOptional();
            Property(p => p.EnumCode).HasColumnName("EnumCode").HasMaxLength(50).IsOptional();

            HasMany(e => e.Contracts)
                .WithOptional(e => e.PaymentType)
                .HasForeignKey(e => e.PaymentTypeId);

            HasMany(e => e.Orders)
                .WithOptional(e => e.PaymentType)
                .HasForeignKey(e => e.PaymentTypeId);
        }
    }
}
