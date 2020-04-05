using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class TradeMarkConfiguration : EntityTypeConfiguration<TradeMark>
    {
        public TradeMarkConfiguration()
        {
            ToTable("TradeMark");
            HasKey(p => p.Id);
            

            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.BrandId).HasColumnName("Brand_Id").IsOptional();
            Property(p => p.VendorId).HasColumnName("Vendor_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(250).IsOptional();

            HasMany(e => e.VendorMaterialNoms)
                 .WithOptional(e => e.TradeMark)
                 .HasForeignKey(e => e.TradeMarkId);
        }
    }
}
