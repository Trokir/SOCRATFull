using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OrderStatusConfiguration : EntityTypeConfiguration<OrderStatus>
    {
        public OrderStatusConfiguration()
        {
            ToTable("OrderStatus");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.OrderNum).HasColumnName("OrderNum").IsOptional();
            Property(p => p.Description).HasColumnName("Description").HasMaxLength(300).IsOptional();
            Property(p => p.CustomerMessage).HasColumnName("CustomerMessage").IsOptional();
            Property(p => p.ColorRGB).HasColumnName("Color").IsOptional();
            Property(p => p.ChangeMap).HasColumnName("ChangeMap").IsOptional();

            HasMany(e => e.Orders)
                .WithOptional(e => e.OrderStatus)
                .HasForeignKey(e => e.OrderStatusId);

            HasMany(e => e.OrderStatusHistories)
                .WithOptional(e => e.NewOrderStatus)
                .HasForeignKey(e => e.NewOrderStatusId);
        }
    }
}
