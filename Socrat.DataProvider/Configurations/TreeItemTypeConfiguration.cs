using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class TreeItemTypeConfiguration : EntityTypeConfiguration<TreeItemType>
    {
        public TreeItemTypeConfiguration()
        {
            ToTable("TreeItemType");
            HasKey(p => p.Id);
            

            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            Property(p => p.TreeItemTypeNum).HasColumnName("TreeItemTypeNum").IsOptional();

            HasMany(e => e.TreeItems)
                .WithRequired(e => e.TreeItemType)
                .HasForeignKey(e => e.TreeItemTypeId);
        }
    }
}
