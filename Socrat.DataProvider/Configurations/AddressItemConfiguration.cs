using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AddressItemConfiguration : EntityTypeConfiguration<AddressItem>
    {
        public AddressItemConfiguration()
        {
            ToTable("AddressItem");
            HasKey(p => p.Id);

            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
            Property(p => p.AddressElementId).HasColumnName("AddressElement_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(100).IsOptional();
        }
    }
}
