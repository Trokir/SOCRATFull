using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Parsers;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerOrderRowFrameConfiguration : EntityTypeConfiguration<CustomerOrderRowFrame>
    {
        public CustomerOrderRowFrameConfiguration()
        {
            ToTable("CustomerOrderRowFrame");
            HasKey(p => p.Id);
        }
    }
}