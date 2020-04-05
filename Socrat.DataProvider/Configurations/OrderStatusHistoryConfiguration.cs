using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OrderStatusHistoryConfiguration : EntityTypeConfiguration<OrderStatusHistory>
    {
        public OrderStatusHistoryConfiguration()
        {
            ToTable("OrderStatusHistory");
            HasKey(p => p.Id);
            

            Property(p => p.OrderId).HasColumnName("Order_Id").IsOptional();
            Property(p => p.DateChange).HasColumnName("DateChange").IsOptional();
            Property(p => p.NewOrderStatusId).HasColumnName("NewOrderStatus_Id").IsOptional();
            Property(p => p.UserId).HasColumnName("User_Id").IsOptional();
        }
    }
}
