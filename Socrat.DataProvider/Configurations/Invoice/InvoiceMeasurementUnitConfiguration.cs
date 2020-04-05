using Socrat.Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class InvoiceMeasurementUnitConfiguration : EntityTypeConfiguration<InvoiceMeasurementUnit>
    {
        public InvoiceMeasurementUnitConfiguration()
        {
            ToTable("InvoiceMeasurementUnit");
            HasKey(p => p.Id);

            Property(p => p.MeasureId).HasColumnName("Measure_Id").IsRequired();
            Property(p => p.IsDefault).HasColumnName("IsDefault").HasColumnType("bit").IsRequired();

            HasMany(e => e.Invoices)
                .WithRequired(e => e.InvoiceMeasurementUnit)
                .HasForeignKey(e => e.InvoiceMeasurementUnitId);

            HasMany(e => e.InvoiceItems)
               .WithRequired(e => e.InvoiceMeasurementUnit)
               .HasForeignKey(e => e.InvoiceMeasurementUnitId);
        }
    }
}
