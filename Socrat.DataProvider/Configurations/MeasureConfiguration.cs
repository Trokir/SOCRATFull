using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MeasureConfiguration : EntityTypeConfiguration<Measure>
    {
        public MeasureConfiguration()
        {
            ToTable("Measure");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(30).IsOptional();
            Property(p => p.OkeiCode).HasColumnName("OkeiCode").IsOptional();

            HasMany(e => e.MaterialSizeTypes)
                .WithOptional(e => e.Measure)
                .HasForeignKey(e => e.MeasureId);

            HasMany(e => e.ProcessingTypes)
                .WithOptional(e => e.Measure)
                .HasForeignKey(e => e.MeasureId);
        }
    }
}
