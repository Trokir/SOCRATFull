using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PricePeriodConfiguration : EntityTypeConfiguration<PricePeriod>
    {
        public PricePeriodConfiguration()
        {
            ToTable("PricePeriod");
            HasKey(p => p.Id);
            

            Property(p => p.PriceId).HasColumnName("Price_Id").IsOptional();
            Property(p => p.DateBegin).HasColumnName("DateBegin").IsOptional();
            Property(p => p.BaseSpo).HasColumnName("BaseSpo").HasColumnType("float").IsOptional();
            Property(p => p.BaseSpd).HasColumnName("BaseSpd").HasColumnType("float").IsOptional();

            HasMany(e => e.PriceLogs)
                .WithOptional(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);

            HasMany(e => e.PriceProcessings)
                .WithOptional(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);

            HasMany(e => e.PriceValues)
                .WithOptional(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);
        }
    }
}
