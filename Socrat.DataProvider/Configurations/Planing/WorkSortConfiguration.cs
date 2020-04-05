using Socrat.Core.Entities.Planing;
using System.Data.Entity.ModelConfiguration;

namespace Socrat.DataProvider.Configurations.Planing
{
    public class WorkSortConfiguration: EntityTypeConfiguration<WorkSort>
    {
        public WorkSortConfiguration()
        {
            ToTable("WorkSorts");
            HasKey(p => p.Id);
            Property(p => p.WorkSortTypeId).HasColumnName("WorkSortType_Id").IsOptional();
            Property(p => p.WorSortDesc).HasColumnName("WorSortDesc").IsOptional();
            Property(p => p.WorkSortPosition).HasColumnName("WorkSortPosition").IsOptional();
            Property(p => p.WorkSortDescription).HasColumnName("WorkSortDescription").IsOptional();
            Property(p => p.WorkSortNumber).HasColumnName("WorkSortNumber").IsOptional();
        }
    }
}
