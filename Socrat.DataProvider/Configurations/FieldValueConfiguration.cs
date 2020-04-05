using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FieldValueConfiguration : EntityTypeConfiguration<FieldValue>
    {
        public FieldValueConfiguration()
        {
            ToTable("FieldValue");
            HasKey(p => p.Id);

            Property(p => p.FieldId).HasColumnName("Field_Id").IsOptional();
            Property(p => p.Value).HasColumnName("Value").HasMaxLength(50).IsOptional();
        }
    }
}
