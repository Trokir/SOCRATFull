using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class DateTimeRangeConfiguration : EntityTypeConfiguration<DateTimeRange>
    {
        public DateTimeRangeConfiguration()
        {
            ToTable("DateTimeRange");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.Start).HasColumnName("Start").IsOptional();
            Property(p => p.Finish).HasColumnName("Finish").IsOptional();
        }
    }
}
