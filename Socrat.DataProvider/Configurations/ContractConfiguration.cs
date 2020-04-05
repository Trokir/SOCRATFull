using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ContractConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractConfiguration()
        {
            ToTable("Contract");
            HasKey(p => p.Id);

            Property(p => p.Num).HasColumnName("Num").HasColumnType("bigint").IsOptional();
            Property(p => p.ContractTypeId).HasColumnName("ContractType_Id").IsOptional();
            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.CoworkerId).HasColumnName("Coworker_Id").IsOptional();
            Property(p => p.DateBegin).HasColumnName("DateBegin").IsOptional();
            Property(p => p.DateEnd).HasColumnName("DateEnd").IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(100).IsOptional();
            Property(p => p.Confirmed).HasColumnName("Confirmed").HasColumnType("bit").IsOptional();
            Property(p => p.PaymentTypeId).HasColumnName("PaymentType_Id").IsOptional();
            Property(p => p.PaymentBeforeDay).HasColumnName("PaymentBeforeDay").HasColumnType("smallint").IsOptional();
            Property(p => p.PaymentBeforePercent).HasColumnName("PaymentBeforePercent").HasColumnType("float").IsOptional();
            Property(p => p.PaymentBeforeAmount).HasColumnName("PaymentBeforeAmount").IsOptional();
            Property(p => p.PaymentReadyPercent).HasColumnName("PaymentReadyPercent").HasColumnType("float").IsOptional();
            Property(p => p.PaymentReadyAmount).HasColumnName("PaymentReadyAmount").IsOptional();
            Property(p => p.PaymentAfterDay).HasColumnName("PaymentAfterDay").HasColumnType("smallint").IsOptional();
            Property(p => p.PaymentCreditLimit).HasColumnName("PaymentCreditLimit").IsOptional();
            Property(p => p.BillValidityPeriod).HasColumnName("BillValidityPeriod").HasColumnType("smallint").IsOptional();
            Property(p => p.PriceRegionId).HasColumnName("PriceRegion_Id").IsOptional();
            Property(p => p.PriceChangeDayInfo).HasColumnName("PriceChangeDayInfo").HasColumnType("smallint").IsOptional();
            Property(p => p.PriceChangeDate).HasColumnName("PriceChangeDate").IsOptional();
            Property(p => p.EditorPrice).HasColumnName("EditorPrice").HasMaxLength(31).IsOptional();
            Property(p => p.EditorShippingPrice).HasColumnName("EditorShippingPrice").HasMaxLength(31).IsOptional();
            Property(p => p.ShippingPriceChangeDate).HasColumnName("ShippingPriceChangeDate").IsOptional();
            Property(p => p.Spec).HasColumnName("Spec").HasColumnType("bit").IsOptional();
            Property(p => p.DaysForProduct).HasColumnName("DaysForProduct").HasColumnType("tinyint").IsOptional();
            Property(p => p.DateTransferTime).HasColumnName("DateTransferTime").IsOptional();
            Property(p => p.Default).HasColumnName("Default").IsOptional();
            Ignore(p => p.DateTransferDateTime);

            HasMany(e => e.ContractAddresses)
                .WithOptional(e => e.Contract)
                .HasForeignKey(e => e.ContractId);

            HasMany(e => e.ContractPrices)
                .WithOptional(e => e.Contract)
                .HasForeignKey(e => e.ContractId);

            HasMany(e => e.ContractShippingSquares)
                .WithOptional(e => e.Contract)
                .HasForeignKey(e => e.ContractId)
                .WillCascadeOnDelete();

            HasMany(e => e.ContractTenderFormulas)
                .WithOptional(e => e.Contract)
                .HasForeignKey(e => e.ContractId);

            HasMany(e => e.Orders)
                .WithOptional(e => e.Contract)
                .HasForeignKey(e => e.ContractId);
        }
    }
}
