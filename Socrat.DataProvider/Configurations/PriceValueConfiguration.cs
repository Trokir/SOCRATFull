using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceValueConfiguration : EntityTypeConfiguration<PriceValue>
    {
        public PriceValueConfiguration()
        {
            ToTable("PriceValue");
            HasKey(p => p.Id);

            Property(p => p.PricePeriodId).HasColumnName("PricePeriod_Id").IsOptional();
            Property(p => p.PriceTypeId).HasColumnName("PriceType_Id").IsOptional();
            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsOptional();
            Property(p => p.PriceVal).HasColumnName("PriceVal").HasColumnType("float").IsOptional();

            HasMany(e => e.PriceLogs)
                .WithOptional(e => e.PriceValue)
                .HasForeignKey(e => e.PriceValueId).WillCascadeOnDelete(true);
        }
    }
}
