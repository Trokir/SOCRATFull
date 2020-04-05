using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AddressElementConfiguration : EntityTypeConfiguration<AddressElement>
    {
        public AddressElementConfiguration()
        {
            ToTable("AddressElement");
            HasKey(p => p.Id);

            Property(p => p.AddressElementTypeId).HasColumnName("AddressElementType_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.ShortName).HasColumnName("NameShort").HasMaxLength(20).IsOptional();
            Property(p => p.Code).HasColumnName("Code").HasMaxLength(10).IsOptional();

            HasMany(e => e.AddressItems)
                .WithOptional(e => e.AddressElement)
                .HasForeignKey(e => e.AddressElementId);
        }
    }
}
