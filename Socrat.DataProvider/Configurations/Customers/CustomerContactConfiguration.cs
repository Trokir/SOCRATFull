using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class CustomerContactConfiguration : EntityTypeConfiguration<CustomerContact>
    {
        public CustomerContactConfiguration()
        {
            ToTable("CustomerContact");
            HasKey(p => p.Id);

            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.ContactTypeId).HasColumnName("ContactType_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(100).IsOptional();
        }
    }
}
