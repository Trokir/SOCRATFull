using System;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.WayBills;

namespace Socrat.DataProvider.Configurations.Waybills
{
    public class WaybillRowConfiguration : EntityTypeConfiguration<WaybillRow>
    {
        public WaybillRowConfiguration()
        {
            ToTable("WaybillRow");
            HasKey(p => p.Id);

            Property(p => p.Text).HasColumnName("Text").HasMaxLength(1024).IsRequired();
            Property(p => p.ProductionMovementId).HasColumnName("ProductionMovement_Id").IsRequired();
            Property(p => p.Quantity).HasColumnName("Quantity").IsRequired();
            Property(p => p.PricePerItem).HasColumnName("PricePerItem").IsRequired();
            Property(p => p.Items).HasColumnName("Items").IsRequired();
            Property(p => p.PricePerRow).HasColumnName("PricePerRow").IsRequired();
            Property(p => p.VatRate).HasColumnName("VatRate").IsRequired();
            Property(p => p.VatValue).HasColumnName("VatValue").IsRequired();
            Property(p => p.Weight).HasColumnName("Weight").IsRequired();

            HasMany(e => e.ProductionItems)
            .WithRequired(e => e.WaybillRow)
            .HasForeignKey(e => e.WaybillRowId);
        }
    }
}
