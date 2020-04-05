using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class TimeRangeConfiguration : EntityTypeConfiguration<TimeRange>
    {
        public TimeRangeConfiguration()
        {
            ToTable("TimeRange");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.StartRange).HasColumnName("StartRange").IsOptional();
            Property(p => p.EndRange).HasColumnName("EndRange").IsOptional();
            Property(p => p.Days).HasColumnName("Days").IsOptional();

            HasMany(e => e.CoworkerContacts)
                .WithOptional(e => e.TimeRange)
                .HasForeignKey(e => e.TimeRangeId);
        }
    }
}
