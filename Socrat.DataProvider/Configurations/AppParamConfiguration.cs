using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class AppParamConfiguration : EntityTypeConfiguration<AppParam>
    {
        public AppParamConfiguration()
        {
            ToTable("AppParams");
            HasKey(p => p.Id);

            Property(p => p.Category).HasColumnName("Category").HasMaxLength(150).IsOptional();
            Property(p => p.Alias).HasColumnName("Alias").HasMaxLength(150).IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(300).IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(400).IsOptional();
            Ignore(p => p.ParamAlias);
        }
    }
}
