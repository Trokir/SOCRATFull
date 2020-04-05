using Socrat.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class PaymentConfiguration : EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            ToTable("Payment");
            HasKey(p => p.Id);

            Property(p => p.ContractId).HasColumnName("Contract_Id").IsRequired();
            Property(p => p.PaymentTypeId).HasColumnName("PaymentType_Id").IsRequired();
            Property(p => p.Dated).HasColumnName("Dated").HasColumnType("datetime2").IsRequired();
            Property(p => p.Sum).HasColumnName("Sum").HasColumnType("float").IsRequired();
            Property(p => p.IcRef).HasColumnName("IcRef").HasMaxLength(100).IsOptional();
            Property(p => p.Comments).HasColumnName("Comments").HasMaxLength(1024).IsOptional();

            HasMany(e => e.InvoicePayments)
                .WithRequired(e => e.Payment)
                .HasForeignKey(e => e.PaymentId);
        }
    }
}
