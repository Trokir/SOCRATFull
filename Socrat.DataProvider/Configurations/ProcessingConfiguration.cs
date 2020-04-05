using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ProcessingConfiguration : EntityTypeConfiguration<Processing>
    {
        public ProcessingConfiguration()
        {
            ToTable("Processings");
            HasKey(p => p.Id);
            
            Property(p => p.ShortName).HasColumnName("ShortName").HasMaxLength(50).IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(200).IsOptional();
            Property(p => p.Step).HasColumnName("Step").IsOptional();
            Property(p => p.ProcessingTypeId).HasColumnName("ProcessingTypeId").IsOptional();
            Property(p => p.SlozTypeId).HasColumnName("SlozTypeId").IsOptional();
            Property(p => p.OutcropSize).HasColumnName("OutcropSize").IsOptional();
            Property(p => p.OutcropType).HasColumnName("OutcropType").IsOptional();
            Property(p => p.ColorRGB).HasColumnName("Color").IsOptional();
            Ignore(p => p.Title);

            HasMany(e => e.PriceProcessings)
                .WithOptional(e => e.Processing)
                .HasForeignKey(e => e.ProcessingId);

            HasMany(e => e.FormulaItemProcessings)
                .WithOptional(e => e.Processing)
                .HasForeignKey(e => e.ProcessingId)
                .WillCascadeOnDelete(true);
        }
    }
}
