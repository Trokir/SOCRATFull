using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialConfiguration : EntityTypeConfiguration<Material>
    {
        public MaterialConfiguration()
        {
            ToTable("Material");
            HasKey(p => p.Id);
           
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.MaterialTypeId).HasColumnName("MaterialType_Id").IsOptional();
            Property(p => p.EnumCode).HasColumnName("EnumCode").HasMaxLength(30).IsOptional();

            HasMany(e => e.Brands)
                 .WithOptional(e => e.Material)
                 .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.FormulaItems)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId)
                .WillCascadeOnDelete();

            HasMany(e => e.MaterialFields)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId)
                .WillCascadeOnDelete();

            HasMany(e => e.MaterialMarkTypes)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.MaterialSpecProperties)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.PriceTypes)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.ProcessingTypes)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.TradeMarks)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.VendorMaterials)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.VendorMaterialNoms)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);

            HasMany(e => e.ProcessingTypes)
                .WithOptional(e => e.Material)
                .HasForeignKey(e => e.MaterialId);
        }
    }
}
