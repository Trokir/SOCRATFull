using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ProcessingComponentConfiguration : EntityTypeConfiguration<ProcessingComponent>
    {
        public ProcessingComponentConfiguration()
        {
            ToTable("ProcessingComponent");
            HasKey(p => p.Id);

            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsOptional();
            Property(p => p.MeasureId).HasColumnName("Measure_Id").IsOptional();
            Property(p => p.FormulaItemProcessingId).HasColumnName("FormulaItemProcessing_Id").IsOptional();
            Property(p => p.Qty).HasColumnName("Qty").IsOptional();
        }
    }
}