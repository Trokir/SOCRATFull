using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class ProsessingMaterialMarkTypeConfiguration : EntityTypeConfiguration<ProcessingMaterialMarkType>
    {
        public ProsessingMaterialMarkTypeConfiguration()
        {
            ToTable("ProsessingsMaterialMarkTypes");
            HasKey(p => p.Id);
        }
    }
}