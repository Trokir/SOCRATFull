using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AddressElementTypeConfiguration : EntityTypeConfiguration<AddressElementType>
    {
        public AddressElementTypeConfiguration()
        {
            ToTable("AddressElementType");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.Code).HasColumnName("Code").HasMaxLength(10).IsOptional();
            Property(p => p.Sort).HasColumnName("Sort").HasColumnType("smallint").IsOptional();
            Property(p => p.AddressElementTypeNum).HasColumnName("AddressElementTypeNum").IsOptional();

            HasMany(e => e.AddressElements)
                .WithOptional(e => e.AddressElementType)
                .HasForeignKey(e => e.AddressElementTypeId);
        }
    }
}
