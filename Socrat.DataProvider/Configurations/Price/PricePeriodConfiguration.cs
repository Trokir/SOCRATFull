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

            Property(p => p.PriceId).HasColumnName("Price_Id").IsRequired();
            Property(p => p.DateBegin).HasColumnName("DateBegin").IsRequired();
            Property(p => p.BaseSpo).HasColumnName("BaseSpo").HasColumnType("float").IsRequired();
            Property(p => p.BaseSpd).HasColumnName("BaseSpd").HasColumnType("float").IsRequired();
            Property(p => p.FormulaSpoId).HasColumnName("FormulaSpoId").IsRequired();
            Property(p => p.FormulaSpdId).HasColumnName("FormulaSpdId").IsRequired();

            HasMany(e => e.PricePeriodProcessingNoms)
                .WithRequired(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);

            HasMany(e => e.PriceValues)
                .WithRequired(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);

            HasMany(e => e.PricePeriodMaterialMarkTypes)
                .WithRequired(e => e.PricePeriod)
                .HasForeignKey(e => e.PricePeriodId);
        }
    }
}
