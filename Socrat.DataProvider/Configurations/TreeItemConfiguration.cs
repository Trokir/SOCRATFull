using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class TreeItemConfiguration : EntityTypeConfiguration<TreeItem>
    {
        public TreeItemConfiguration()
        {
            ToTable("TreeItem");
            HasKey(p => p.Id);
            

            Property(p => p.TreeItemTypeId).HasColumnName("TreeItemType_Id").IsRequired();
            Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            Property(p => p.ParentTreeItemId).HasColumnName("ParentTreeItem_Id").IsOptional();
            Property(p => p.ModuleId).HasColumnName("Module_Id").IsOptional();
            Property(p => p.SortNum).HasColumnName("SortNum").HasColumnType("smallint").IsOptional();
            Ignore(p => p.NodeInited);
            HasMany(e => e.RoleTreeItems)
                .WithRequired(e => e.TreeItem)
                .HasForeignKey(e => e.TreeItemId);

            HasMany(e => e.TreeItems)
                .WithOptional(e => e.ParentTreeItem)
                .HasForeignKey(e => e.ParentTreeItemId);
        }
    }
}
