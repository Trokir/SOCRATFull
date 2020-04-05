using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceSelectTypeConfiguration : EntityTypeConfiguration<PriceSelectType>
    {
        public PriceSelectTypeConfiguration()
        {
            ToTable("PriceSelectType");
            HasKey(p => p.Id);
            

            Property(p => p.PriceId).HasColumnName("Price_Id").IsOptional();
            Property(p => p.PriceTypeId).HasColumnName("PriceType_Id").IsOptional();
        }
    }
}
