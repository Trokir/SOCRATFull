using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialTypeConfiguration : EntityTypeConfiguration<MaterialType>
    {
        public MaterialTypeConfiguration()
        {
            ToTable("MaterialType");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsOptional();
            Property(p => p.DbTable).HasColumnName("DbTable").HasMaxLength(10).IsOptional();

            HasMany(e => e.Materials)
                .WithOptional(e => e.MaterialType)
                .HasForeignKey(e => e.MaterialTypeId);
        }
    }
}
