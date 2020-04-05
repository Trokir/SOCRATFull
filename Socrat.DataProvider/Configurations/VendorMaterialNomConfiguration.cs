using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class VendorMaterialNomConfiguration : EntityTypeConfiguration<VendorMaterialNom>
    {
        public VendorMaterialNomConfiguration()
        {
            ToTable("VendorMaterialNom");
            HasKey(p => p.Id);
            

            Property(p => p.VendorId).HasColumnName("Vendor_Id").IsOptional();
            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.BrandId).HasColumnName("Brand_Id").IsOptional();
            Property(p => p.TradeMarkId).HasColumnName("TradeMark_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(150).IsOptional();
            Property(p => p.MaterialMarkTypeId).HasColumnName("MaterialMarkType_Id").IsOptional();
            Property(p => p.ColorRal).HasColumnName("ColorRAL").HasMaxLength(10).IsFixedLength().IsOptional();
            Property(p => p.ColorTransparency).HasColumnName("ColorTransparency").HasColumnType("float").IsOptional();
            Property(p => p.Mark).HasColumnName("Mark").HasMaxLength(10).IsOptional();

            HasMany(e => e.MaterialNoms)
                .WithOptional(e => e.VendorMaterialNom)
                .HasForeignKey(e => e.VendorMaterialNomId);
        }
    }
}
