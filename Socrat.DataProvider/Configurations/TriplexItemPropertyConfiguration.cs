using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class TriplexItemPropertyConfiguration : EntityTypeConfiguration<TriplexItemProperty>
    {
        public TriplexItemPropertyConfiguration()
        {
            ToTable("TriplexItemProperties");
            HasKey(p => p.Id);

            Property(p => p.Dent).HasColumnName("Dent").HasColumnType("bit").IsOptional();
            HasRequired(p => p.TriplexItem).WithOptional(p => p.TriplexItemProperty);
        }
    }
}
