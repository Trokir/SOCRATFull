using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DivisionCustomerConfiguration : EntityTypeConfiguration<DivisionCustomer>
    {
        public DivisionCustomerConfiguration()
        {
            ToTable("DivisionCustomer");
            HasKey(p => p.Id);

            Property(p => p.DivisionId).HasColumnName("Division_Id").IsOptional();
            Property(p => p.CustomerId).HasColumnName("Customer_Id").IsOptional();
            Property(p => p.Default).HasColumnName("Default").HasColumnType("bit").IsOptional();
        }
    }
}
