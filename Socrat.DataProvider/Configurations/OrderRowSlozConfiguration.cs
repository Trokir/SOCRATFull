using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class OrderRowSlozConfiguration : EntityTypeConfiguration<OrderRowSloz>
    {
        public OrderRowSlozConfiguration()
        {
            ToTable("OrderRowSloz");
            HasKey(p => p.Id);
            
            
            Property(p => p.OrderRowId).HasColumnName("OrderRow_Id").IsOptional();
            Property(p => p.SlozTypeId).HasColumnName("SlozType_Id").IsOptional();
        }
    }
}
