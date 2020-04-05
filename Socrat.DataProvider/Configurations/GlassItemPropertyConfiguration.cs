using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class GlassItemPropertyConfiguration : EntityTypeConfiguration<GlassItemProperty>
    {
        public GlassItemPropertyConfiguration()
        {
            ToTable("GlassItemProperties");
            HasKey(p => p.Id);

            Property(p => p.Dent).HasColumnName("Dent").HasColumnType("bit").IsOptional();

            HasRequired(p => p.GlassItem)
                .WithRequiredDependent(p => p.GlassItemProperty);
        }
    }
}
