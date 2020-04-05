using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Parsers;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerOrderRowItemConfiguration : EntityTypeConfiguration<CustomerOrderRowItem>
    {
        public CustomerOrderRowItemConfiguration()
        {
            ToTable("CustomerOrderRowItem");
            HasKey(p => p.Id);

            HasMany(e => e.OrderRowItems)
                .WithOptional(e => e.CustomerOrderRowItem)
                .HasForeignKey(e => e.CustomerOrderRowItemId);
        }
    }
}