using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerPropConfiguration : EntityTypeConfiguration<CustomerProp>
    {
        public CustomerPropConfiguration()
        {
            ToTable("CustomerProp");
            HasKey(p => p.Id);

            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.CustomerPropTypeId).HasColumnName("CustomerPropType_Id").IsOptional();
            Property(e => e.Value).HasColumnName("Value").HasMaxLength(1024).IsFixedLength().IsOptional();
        }
    }
}
