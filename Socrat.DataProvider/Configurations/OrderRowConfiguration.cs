using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OrderRowConfiguration : EntityTypeConfiguration<OrderRow>
    {
        public OrderRowConfiguration()
        {
            ToTable("OrderRow");
            HasKey(p => p.Id);
            

            Property(p => p.Num).HasColumnName("Num").IsRequired();
            Property(p => p.OrderId).HasColumnName("Order_Id").IsOptional();
            Property(p => p.OverallW).HasColumnName("OverallW").IsOptional();
            Property(p => p.OverallH).HasColumnName("OverallH").IsOptional();
            Property(p => p.Qty).HasColumnName("Qty").IsOptional();
            Property(p => p.Mark).HasColumnName("Mark").HasMaxLength(100).IsOptional();
            Property(p => p.Barcode).HasColumnName("Barcode").HasMaxLength(100).IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(200).IsOptional();
            Property(p => p.PriceSqu).HasColumnName("PriceSqu").HasColumnType("float").IsOptional();
            Property(p => p.PriceRatio).HasColumnName("PriceRatio").HasColumnType("float").IsOptional();
            Property(p => p.PriceItem).HasColumnName("PriceItem").HasColumnType("float").IsOptional();
            Property(p => p.PriceRow).HasColumnName("PriceRow").HasColumnType("float").IsOptional();
            Property(p => p.FormulaId).HasColumnName("Formula_Id").IsOptional();
            Property(p => p.ShapeId).HasColumnName("Shape_Id").IsOptional();
            Ignore(p => p.FormulaStr);

            HasMany(e => e.OrderRowSlozs)
                .WithOptional(e => e.OrderRow)
                .HasForeignKey(e => e.OrderRowId);
        }
    }
}
