using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ShapeConfiguration : EntityTypeConfiguration<Shape>
    {
        public ShapeConfiguration()
        {
            ToTable("Shape");
            HasKey(p => p.Id);
            Property(p => p.SidesCount).HasColumnName("SidesCount").IsOptional();
            Property(p => p.CatalogNumber).HasColumnName("CatalogNumber").IsOptional();
            Property(p => p.IsCatalogShape).HasColumnName("IsCatalogShape").HasColumnType("bit").IsOptional();
            Property(p => p.ShapeImage).HasColumnName("ShapeImage").HasColumnType("image").IsOptional();

              HasMany(e => e.ShapePoints)
                .WithRequired(e => e.Shape)
                .HasForeignKey(e => e.ShapeId)
                .WillCascadeOnDelete();

            HasMany(e => e.OrderRows)
             .WithRequired(e => e.Shape)
             .HasForeignKey(e => e.ShapeId);

            HasRequired(e => e.ShapeParam)
                .WithOptional(e => e.Shape)
                .WillCascadeOnDelete();

            HasRequired(e => e.ShapeModifedParam)
                .WithOptional(e => e.Shape)
             .WillCascadeOnDelete();
        }
    }
}
