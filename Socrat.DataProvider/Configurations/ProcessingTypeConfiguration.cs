using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ProcessingTypeConfiguration : EntityTypeConfiguration<ProcessingType>
    {
        public ProcessingTypeConfiguration()
        {
            ToTable("ProcessingTypes");
            HasKey(p => p.Id);

            Property(p => p.ShortName).HasColumnName("ShortName").HasMaxLength(50).IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(200).IsOptional();
            Property(p => p.Step).HasColumnName("Step").IsOptional();
            Property(p => p.ColorRGB).HasColumnName("Color").IsOptional();
            Property(p => p.MeasureId).HasColumnName("MeasureId").IsOptional();
            Property(p => p.MaterialId).HasColumnName("MaterialId").IsOptional();
            Ignore(p => p.Title);

            HasMany(e => e.Processings)
                .WithOptional(e => e.ProcessingType)
                .HasForeignKey(e => e.ProcessingTypeId);
        }
    }
}