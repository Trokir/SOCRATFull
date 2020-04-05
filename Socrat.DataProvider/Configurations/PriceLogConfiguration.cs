using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceLogConfiguration : EntityTypeConfiguration<PriceLog>
    {
        public PriceLogConfiguration()
        {
            ToTable("PriceLog");
            HasKey(p => p.Id);
            

            Property(p => p.Date).HasColumnName("Date").IsOptional();
            Property(p => p.Editor).HasColumnName("Editor").HasMaxLength(31).IsUnicode(false).IsOptional();
            Property(p => p.PricePeriodId).HasColumnName("PricePeriod_Id").IsOptional();
            Property(p => p.PriceTypeId).HasColumnName("PriceType_Id").IsOptional();
            Property(p => p.MaterialNomId).HasColumnName("MaterialNom_Id").IsOptional();
            Property(p => p.PriceValueId).HasColumnName("PriceValue_Id").IsOptional();
            Property(p => p.OldValue).HasColumnName("OldValue").HasColumnType("float").IsOptional();
        }
    }
}
