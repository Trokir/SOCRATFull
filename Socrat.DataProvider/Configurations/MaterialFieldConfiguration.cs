using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialFieldConfiguration : EntityTypeConfiguration<MaterialField>
    {
        public MaterialFieldConfiguration()
        {
            ToTable("MaterialField");
            HasKey(p => p.Id);

            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.FieldId).HasColumnName("Field_Id").IsOptional();
        }
    }
}
