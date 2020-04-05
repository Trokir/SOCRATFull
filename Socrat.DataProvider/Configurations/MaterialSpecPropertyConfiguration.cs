using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class MaterialSpecPropertyConfiguration : EntityTypeConfiguration<MaterialSpecProperty>
    {
        public MaterialSpecPropertyConfiguration()
        {
            ToTable("MaterialSpecProperty");
            HasKey(p => p.Id);
            

            Property(p => p.MaterialId).HasColumnName("Material_Id").IsOptional();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsOptional();
            Property(p => p.Comment).HasColumnName("Comment").HasMaxLength(100).IsOptional();
        }
    }
}
