using Socrat.Core.Entities.Planing;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations.Planing
{
    class WorkSortFieldConfiguration : EntityTypeConfiguration<WorkSortField>
    {
        public WorkSortFieldConfiguration()
        {
            ToTable("WorkSortFields");
            HasKey(p => p.Id);
            Property(p => p.WSortField).HasColumnName("WorkSortField").IsRequired();
            Property(p => p.WSortName).HasColumnName("WorkSortName").IsRequired();
            HasMany(e => e.WorkSorts)
                .WithOptional(e => e.WorkSortField)
                .HasForeignKey(e => e.WorkSortFieldsId);
        }
    }
}
