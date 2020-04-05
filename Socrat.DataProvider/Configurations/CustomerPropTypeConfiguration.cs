using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerPropTypeConfiguration : EntityTypeConfiguration<CustomerPropType>
    {
        public CustomerPropTypeConfiguration()
        {
            ToTable("CustomerPropType");
            HasKey(p => p.Id);

            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(20).IsOptional();
            Property(p => p.PropName).HasColumnName("PropName").HasMaxLength(70).IsOptional();

            HasMany(e => e.CustomerProps)
                .WithOptional(e => e.CustomerPropType)
                .HasForeignKey(e => e.CustomerPropTypeId);
        }
    }
}
