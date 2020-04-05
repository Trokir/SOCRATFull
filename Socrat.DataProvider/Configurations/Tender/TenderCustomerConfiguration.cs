using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.Tender;

namespace Socrat.DataProvider.Configurations
{
    public class TenderCustomerConfiguration : EntityTypeConfiguration<TenderCustomer>
    {
        public TenderCustomerConfiguration()
        {
            ToTable("TenderCustomer");
            HasKey(p => p.Id);
        }
    }
}