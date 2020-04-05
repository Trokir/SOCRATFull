using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerTypeConfiguration : EntityTypeConfiguration<CustomerType>
    {
        public CustomerTypeConfiguration()
        {
            ToTable("CustomerType");
            HasKey(p => p.Id);

            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(20).IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(70).IsOptional();

            HasMany(e => e.Customers)
                .WithOptional(e => e.CustomerType)
                .HasForeignKey(e => e.CustomerTypeId);
        }
    }
}
