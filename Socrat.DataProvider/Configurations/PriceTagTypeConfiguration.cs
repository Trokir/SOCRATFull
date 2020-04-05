using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceTagTypeConfiguration : EntityTypeConfiguration<PriceTagType>
    {
        public PriceTagTypeConfiguration()
        {
            ToTable("PriceTagType");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(40).IsUnicode(false).IsRequired();
            Property(p => p.Designation).HasColumnName("Designation").HasMaxLength(10).IsUnicode(false).IsOptional();

            HasMany(e => e.PriceTypes)
                .WithOptional(e => e.PriceTagType)
                .HasForeignKey(e => e.PriceTagTypeId);
        }
    }
}
