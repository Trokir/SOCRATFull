using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class VirtualPriceItemConfiguration : EntityTypeConfiguration<VirtualPriceItem>
    {
        public VirtualPriceItemConfiguration()
        {
            ToTable("VirtualPriceItem");
            HasKey(p => p.Id);

            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsRequired();
            Property(p => p.PriceValueId).HasColumnName("PriceValue_Id").IsOptional();
            Property(p => p.PricePeriodId).HasColumnName("PricePeriod_Id").IsOptional();
            Property(p => p.Price).HasColumnName("Price").IsOptional();
            Property(p => p.Code1c).HasColumnName("Code1c").IsOptional();
            Property(p => p.FlaggedProductionType).HasColumnName("FlaggedProductionType").HasColumnType("int").IsOptional();
            Property(p => p.MeasureId).HasColumnName("Measure_Id").IsOptional();
            Property(p => p.PriceTopic).HasColumnName("PriceTopic").IsOptional();

        }
    }
}
