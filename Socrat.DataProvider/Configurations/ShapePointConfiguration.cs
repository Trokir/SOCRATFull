using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ShapePointConfiguration : EntityTypeConfiguration<Core.Entities.ShapePoint>
    {
        public ShapePointConfiguration()
        {
            ToTable("ShapePoint");
            HasKey(p => p.Id);
          //  

            Property(p => p.PointName).HasColumnName("PointName").HasMaxLength(20).IsOptional();
            Property(p => p.PointX).HasColumnName("Point_X").HasColumnType("float").IsOptional();
            Property(p => p.PointY).HasColumnName("Point_Y").HasColumnType("float").IsOptional();
            Property(p => p.PointRadius).HasColumnName("PointRadius").HasColumnType("float").IsOptional();
            Property(p => p.ShapeId).HasColumnName("Shape_Id").IsOptional();
        }
    }
}
