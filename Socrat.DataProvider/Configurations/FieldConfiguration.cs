using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class FieldConfiguration : EntityTypeConfiguration<Field>
    {
        public FieldConfiguration()
        {
            ToTable("Field");
            HasKey(p => p.Id);

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(40).IsOptional();
            Property(p => p.IsFixed).HasColumnName("IsFixed").HasColumnType("bit").IsOptional();

            HasMany(e => e.FieldValues)
                .WithOptional(e => e.Field)
                .HasForeignKey(e => e.FieldId)
                .WillCascadeOnDelete();

            HasMany(e => e.MaterialFields)
                .WithOptional(e => e.Field)
                .HasForeignKey(e => e.FieldId)
                .WillCascadeOnDelete();
        }
    }
}
