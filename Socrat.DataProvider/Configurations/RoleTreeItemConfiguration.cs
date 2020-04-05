using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Configurations
{
    public class RoleTreeItemConfiguration : EntityTypeConfiguration<RoleTreeItem>
    {
        public RoleTreeItemConfiguration()
        {
            ToTable("RoleTreeItem");
            HasKey(p => p.Id);
            

            Property(p => p.RoleId).HasColumnName("Role_Id").IsRequired();
            Property(p => p.TreeItemId).HasColumnName("TreeItem_Id").IsRequired();
            Property(p => p.Read).HasColumnName("Read").HasColumnType("bit").IsOptional();
            Property(p => p.Write).HasColumnName("Write").HasColumnType("bit").IsOptional();
        }
    }
}
