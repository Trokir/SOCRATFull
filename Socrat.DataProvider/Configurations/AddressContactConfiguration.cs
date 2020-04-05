using Socrat.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class AddressContactConfiguration : EntityTypeConfiguration<AddressContact>
    {
        public AddressContactConfiguration()
        {
            ToTable("AddressContact");
            HasKey(p => p.Id);

            Property(p => p.AddressId).HasColumnName("Address_Id").IsOptional();
            Property(p => p.ContactTypeId).HasColumnName("ContactType_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(50).IsOptional();
            Property(p => p.WorkPositionId).HasColumnName("WorkPosition_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();

        }
    }
}
