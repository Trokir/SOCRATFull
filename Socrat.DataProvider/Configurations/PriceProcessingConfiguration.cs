using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceProcessingConfiguration : EntityTypeConfiguration<PriceProcessing>
    {
        public PriceProcessingConfiguration()
        {
            ToTable("PriceProcessing");
            HasKey(p => p.Id);
            

            Property(p => p.PricePeriodId).HasColumnName("PricePeriod_Id").IsOptional();
            Property(p => p.ProcessingId).HasColumnName("Processing_Id").IsOptional();
            Property(p => p.Discount).HasColumnName("Discount").HasColumnType("money").HasPrecision(19, 4).IsOptional();
            Property(p => p.Delta).HasColumnName("Delta").HasColumnType("float").IsOptional();
            Property(p => p.EditDate).HasColumnName("Edit").IsOptional();
        }
    }
}
