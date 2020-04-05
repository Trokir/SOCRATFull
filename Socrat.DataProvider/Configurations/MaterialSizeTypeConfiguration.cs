using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialSizeTypeConfiguration : EntityTypeConfiguration<MaterialSizeType>
    {
        public MaterialSizeTypeConfiguration()
        {
            ToTable("MaterialSizeType");
            HasKey(p => p.Id);
            

            Property(p => p.MaterialMarkTypeId).HasColumnName("MaterialMarkType_Id").IsOptional();
            Property(p => p.Thickness).HasColumnName("Thickness").HasColumnType("float").IsRequired();
            Property(p => p.MeasureId).HasColumnName("Measure_Id").IsOptional();
            Property(p => p.DefaultMaterialNomId).HasColumnName("DefaultMaterialNom_Id").IsOptional();

            HasMany(e => e.MaterialNoms)
                 .WithOptional(e => e.MaterialSizeType)
                 .HasForeignKey(e => e.MaterialSizeTypeId);
        }
    }
}
