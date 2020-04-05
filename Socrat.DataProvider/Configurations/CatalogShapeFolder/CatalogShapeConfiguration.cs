using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities.CatalogShapeFolder;


namespace Socrat.DataProvider.Configurations.CatalogShapeFolder
{
 public   class CatalogShapeConfiguration : EntityTypeConfiguration<Core.Entities.CatalogShapeFolder.CatalogShape>
    {
        public CatalogShapeConfiguration()
        {
            ToTable("CatalogShape");
            HasKey(p => p.Id);
            Property(p => p.SidesCount).HasColumnName("SidesCount").IsOptional();
            Property(p => p.CatalogNumber).HasColumnName("CatalogNumber").IsOptional();
            Property(p => p.IsCatalogShape).HasColumnName("IsCatalogShape").HasColumnType("bit").IsOptional();
            Property(p => p.ShapeImage).HasColumnName("ShapeImage").HasColumnType("image").IsOptional();
            Property(p => p.FormTypeId).HasColumnName("FormType_Id").IsOptional();
            Property(p => p.IsDefault).HasColumnName("IsDefault").IsRequired();
            HasMany(e => e.CatalogShapePoints)
                    .WithOptional(e => e.CatalogShape)
                    .HasForeignKey(e => e.ShapeId)
                    .WillCascadeOnDelete();
            HasOptional(e => e.CatalogShapeParam)
              .WithRequired(e => e.CatalogShape)
              .WillCascadeOnDelete();

        }
    }
}
