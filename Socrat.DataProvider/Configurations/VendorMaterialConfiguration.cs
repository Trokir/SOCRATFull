using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class VendorMaterialConfiguration : EntityTypeConfiguration<VendorMaterial>
    {
        public VendorMaterialConfiguration()
        {
            ToTable("VendorMaterial");
            HasKey(p => p.Id);
            

            Property(p => p.VendorId).HasColumnName("Vendor_Id").IsRequired();
            Property(p => p.MaterialId).HasColumnName("Material_Id").IsRequired();

        }
    }
}
