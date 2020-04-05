using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceSquRatioConfiguration : EntityTypeConfiguration<PriceSquRatio>
    {
        public PriceSquRatioConfiguration()
        {
            ToTable("PriceSquRatio");
            HasKey(p => p.Id);
            
            Property(p => p.PriceId).HasColumnName("Price_Id").IsRequired();
            Property(p => p.Squ).HasColumnName("Squ").HasColumnType("float").IsRequired();
            Property(p => p.Ratio).HasColumnName("Ratio").HasColumnType("float").IsRequired();
            Property(p => p.MinPrice).HasColumnName("MinPrice").IsRequired();
        }
    }
}
