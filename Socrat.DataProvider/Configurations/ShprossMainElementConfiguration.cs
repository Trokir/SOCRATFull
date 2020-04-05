using Socrat.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations
{
    public class ShprossMainElementConfiguration : EntityTypeConfiguration<ShprossMainElement>
    {
        public ShprossMainElementConfiguration()
        {
            ToTable("ShprossMainElements");
            HasKey(p => p.Id);
            Property(p => p.Name).HasColumnName("Name").IsOptional();
            Property(p => p.ChordHeight).HasColumnName("ChordHeight").HasColumnType("float").IsOptional();
            Property(p => p.Radius).HasColumnName("Radius").HasColumnType("float").IsOptional();
            Property(p => p.CenterOfRadius).HasColumnName("CenterOfRadius").HasColumnType("float").IsOptional();
            Property(p => p.IsHorisontal).HasColumnName("IsHorisontal").IsOptional();
            Property(p => p.IsVertical).HasColumnName("IsVertical").IsOptional();
            Property(p => p.IsAxis).HasColumnName("IsAxis").IsOptional();
            Property(p => p.ShapeId).HasColumnName("ShapeId").IsOptional();
            Property(p => p.ElementLength).HasColumnName("ElementLength").IsOptional();

            HasMany(e => e.ShapePoints)
             .WithOptional(e => e.ShprossMainElement)
             .HasForeignKey(e => e.ShprossMainElementId);
               // .WillCascadeOnDelete();

            //HasMany(e => e.ShapePoints)
            //  .WithOptional(e => e.ShprossMainElement)
            //  .HasForeignKey(e => e.ShprossMainElementId)
            //  .WillCascadeOnDelete();
          
        }
    }
}
