using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class PriceTypeMarkTypeConfiguration : EntityTypeConfiguration<PriceTypeMarkType>
    {
        public PriceTypeMarkTypeConfiguration()
        {
            ToTable("PriceTypeMarkType");
            HasKey(p => p.Id);

            Property(p => p.PriceTypeId).HasColumnName("PriceType_Id").IsRequired();
            Property(p => p.MaterialMarkTypeId).HasColumnName("MaterialMarkType_Id").IsRequired();
        }
    }
}
