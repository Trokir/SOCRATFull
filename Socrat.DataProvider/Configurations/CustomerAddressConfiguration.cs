using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerAddressConfiguration : EntityTypeConfiguration<CustomerAddress>
    {
        public CustomerAddressConfiguration()
        {
            ToTable("CustomerAddress");
            HasKey(p => p.Id);

            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
        }
    }
}
