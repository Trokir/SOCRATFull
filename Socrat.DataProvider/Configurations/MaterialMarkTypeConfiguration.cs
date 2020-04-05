using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialMarkTypeConfiguration : EntityTypeConfiguration<MaterialMarkType>
    {
        public MaterialMarkTypeConfiguration()
        {
            ToTable("MaterialMarkType");
            HasKey(p => p.Id);

            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(200).IsOptional();
            Property(p => p.Mark).HasColumnName("Mark").HasMaxLength(10).IsOptional();
            Property(p => p.GostMark).HasColumnName("GostMark").HasMaxLength(10).IsUnicode(false).IsOptional();
            Property(p => p.Def).HasColumnName("Def").IsOptional();

            HasMany(e => e.MaterialSizeTypes)
                .WithOptional(e => e.MaterialMarkType)
                .HasForeignKey(e => e.MaterialMarkTypeId);

            HasMany(e => e.PriceTypeMarkTypes)
                .WithOptional(e => e.MaterialMarkType)
                .HasForeignKey(e => e.MaterialMarkTypeId);

            HasMany(e => e.VendorMaterialNoms)
                .WithOptional(e => e.MaterialMarkType)
                .HasForeignKey(e => e.MaterialMarkTypeId);

            HasMany(e => e.PriceTypes)
                .WithOptional(e => e.MaterialMarkType)
                .HasForeignKey(e => e.MaterialMarkTypeId);
        }
    }
}
