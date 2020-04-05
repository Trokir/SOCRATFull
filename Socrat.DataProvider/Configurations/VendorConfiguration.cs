using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class VendorConfiguration : EntityTypeConfiguration<Vendor>
    {
        public VendorConfiguration()
        {
            ToTable("Vendor");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.Description).HasColumnName("Description").HasMaxLength(200).IsOptional();

            HasMany(e => e.Brands)
                .WithOptional(e => e.Vendor)
                .HasForeignKey(e => e.VendorId);

            HasMany(e => e.TradeMarks)
                .WithOptional(e => e.Vendor)
                .HasForeignKey(e => e.VendorId);

            HasMany(e => e.VendorMaterials)
                .WithRequired(e => e.Vendor)
                .HasForeignKey(e => e.VendorId);

            HasMany(e => e.VendorMaterialNoms)
                .WithOptional(e => e.Vendor)
                .HasForeignKey(e => e.VendorId);
        }
    }
}
