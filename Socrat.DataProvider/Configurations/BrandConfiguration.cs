using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class BrandConfiguration : EntityTypeConfiguration<Brand>
    {
        public BrandConfiguration()
        {
            ToTable("Brand");
            HasKey(p => p.Id);

            Property(p => p.VendorId).HasColumnName("Vendor_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(150).IsUnicode(false).IsOptional();
            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();

            HasMany(e => e.TradeMarks)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.BrandId);

            HasMany(e => e.VendorMaterialNoms)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.BrandId);
        }
    }
}
