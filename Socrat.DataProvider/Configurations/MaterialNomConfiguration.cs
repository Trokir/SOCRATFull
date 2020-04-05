using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialNomConfiguration : EntityTypeConfiguration<MaterialNom>
    {
        public MaterialNomConfiguration()
        {
            ToTable("MaterialNom");
            HasKey(p => p.Id);
            

            Property(p => p.VendorMaterialNomId).HasColumnName("VendorMaterialNom_Id").IsOptional();
            Property(p => p.MaterialSizeTypeId).HasColumnName("MaterialSizeType_Id").IsOptional();
            Property(p => p.Code1C).HasColumnName("Code1C").HasMaxLength(12).IsOptional();

            HasMany(e => e.FormulaItems)
                .WithOptional(e => e.MaterialNom)
                .HasForeignKey(e => e.MaterialNomId)
                .WillCascadeOnDelete();

            HasMany(e => e.MaterialSizeTypes)
                .WithOptional(e => e.MaterialNom)
                .HasForeignKey(e => e.DefaultMaterialNomId);

            HasMany(e => e.PriceLogs)
                .WithOptional(e => e.MaterialNom)
                .HasForeignKey(e => e.MaterialNomId);

            HasMany(e => e.PriceValues)
                .WithOptional(e => e.MaterialNom)
                .HasForeignKey(e => e.MaterialNomId);
        }
    }
}
