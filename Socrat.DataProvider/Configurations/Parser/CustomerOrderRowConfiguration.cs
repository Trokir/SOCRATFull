using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Parsers;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerOrderRowConfiguration : EntityTypeConfiguration<CustomerOrderRow>
    {
        public CustomerOrderRowConfiguration()
        {
            ToTable("CustomerOrderRow");
            HasKey(p => p.Id);

            HasMany(e => e.Frames)
                .WithRequired(e => e.CustomerOrderRow)
                .HasForeignKey(e => e.CustomerOrderRowId);

            HasMany(e => e.CustomerOrderRowItems)
                .WithRequired(e => e.CustomerOrderRow)
                .HasForeignKey(e => e.CustomerOrderRowId)
                .WillCascadeOnDelete(true);
        }
    }
}