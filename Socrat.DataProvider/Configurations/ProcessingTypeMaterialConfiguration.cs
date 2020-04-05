using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ProcessingTypeMaterialConfiguration : EntityTypeConfiguration<ProcessingTypeMaterial>
    {
        public ProcessingTypeMaterialConfiguration()
        {
            ToTable("ProcessingTypesMaterials");
            HasKey(p => p.Id);
        }
    }
}