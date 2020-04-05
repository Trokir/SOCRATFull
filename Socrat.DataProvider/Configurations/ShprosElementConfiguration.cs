using Socrat.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.DataProvider.Configurations
{
   public class ShprosElementConfiguration : EntityTypeConfiguration<ShprosElement>
    {
        public ShprosElementConfiguration()
        {
            ToTable("ShprosElements");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasColumnName("Name").IsOptional();
            Property(p => p.OrientationType).HasColumnName("OrientationType").IsOptional();
            Property(p => p.Location).HasColumnName("Location").IsOptional();
            Property(p => p.ShprosCircuitId).HasColumnName("ShprosCircuitId").IsOptional();
            Property(p => p.ShapeId).HasColumnName("ShapeId").IsOptional();
            Property(p => p.TypeElement).HasColumnName("TypeElement").IsOptional();
            Property(p => p.Margin).HasColumnName("Margin").IsOptional();
            Property(p => p.LeftMargin).HasColumnName("LeftMargin").IsOptional();
            Property(p => p.RightMargin).HasColumnName("RightMargin").IsOptional();
            Property(p => p.Count).HasColumnName("Count").IsOptional();
            Property(p => p.SelectorFlag).HasColumnName("SelectorFlag").IsOptional();
            Property(p => p.SideVector).HasColumnName("SideVector").IsOptional();
            Property(p => p.SideDirectionForAxisPack).HasColumnName("SideDirectionForAxisPack").IsOptional();
            Property(p => p.IsCenter).HasColumnName("IsCenter").IsOptional();
            Property(p => p.ChordHeight).HasColumnName("ChordHeight").IsOptional();
            Property(p => p.IsRelativeMargin).HasColumnName("IsRelativeMargin").IsOptional();
            Property(p => p.RelativeMargin).HasColumnName("RelativeMargin").IsOptional();
            Property(p => p.ShprosId).HasColumnName("ShprosId").IsOptional();
            Property(p => p.ChildShprosId).HasColumnName("ChildShprosId").IsOptional();
            Ignore(p => p.ComboItems);
            Ignore(p => p.IsSelectedColor);
            Ignore(p => p.Flag);
        }
    }
}
