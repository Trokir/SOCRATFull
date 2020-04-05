using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FormulaItemProcessingConfiguration : EntityTypeConfiguration<FormulaItemProcessing>
    {
        public FormulaItemProcessingConfiguration()
        {
            ToTable("FormulaItemProcessing");
            HasKey(p => p.Id);

            Property(p => p.FormulaItemId).HasColumnName("FormulaItem_Id").IsOptional();
            Property(p => p.ProcessingId).HasColumnName("Processing_Id").IsOptional();

            HasMany(e => e.Components)
                .WithOptional(e => e.FormulaItemProcessing)
                .HasForeignKey(e => e.FormulaItemProcessingId)
                .WillCascadeOnDelete();
        }
    }
}