using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FrameItemPropertyConfiguration : EntityTypeConfiguration<FrameItemProperty>
    {
        public FrameItemPropertyConfiguration()
        {
            ToTable("FrameItemProperties");
            HasKey(p => p.Id);

            Property(p => p.GermDepth).HasColumnName("GermDepth").HasColumnType("float").IsOptional();
            Property(p => p.Gaz).HasColumnName("Gaz").HasColumnType("bit").IsOptional();

            HasRequired(p => p.FrameItem).WithOptional(p => p.FrameItemProperty);
        }
    }
}
