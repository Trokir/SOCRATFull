using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class InsetPositionConfiguration : EntityTypeConfiguration<InsetPosition>
    {
        public InsetPositionConfiguration()
        {
            ToTable("InsetPosition");
            HasKey(p => p.Id);

            Property(p => p.Num).HasColumnName("Num").HasColumnType("tinyint").IsOptional();
            Property(p => p.SideNum).HasColumnName("SideNum").HasColumnType("tinyint").IsOptional();
            Property(p => p.Position).HasColumnName("Position").HasMaxLength(100).IsOptional();
            Property(p => p.InsetItemPropertyId).HasColumnName("InsetItemProperty_Id").IsOptional();
        }
    }
}
