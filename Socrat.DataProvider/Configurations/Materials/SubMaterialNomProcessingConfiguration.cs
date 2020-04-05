using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class SubMaterialNomProcessingConfiguration : EntityTypeConfiguration<SubMaterialNomProcessing>
    {
        public SubMaterialNomProcessingConfiguration()
        {
            ToTable("SubMaterialNomProcessing");
            HasKey(p => p.Id);
        }
    }
}