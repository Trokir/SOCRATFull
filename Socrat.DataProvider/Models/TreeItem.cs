using System;
using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class TreeItem : Entity
    {
        public TreeItem()
        {
            RoleTreeItems = new HashSet<RoleTreeItem>();
            TreeItems = new HashSet<TreeItem>();
            TreeItemTemplates = new HashSet<TreeItemTemplate>();
        }

        public Guid TreeItemTypeId { get; set; }
        public string Name { get; set; }
        public Guid? ParentTreeItemId { get; set; }
        public Guid? ModuleId { get; set; }
        public short? SortNum { get; set; }
        public virtual Module Module { get; set; }
        public virtual ICollection<TreeItemTemplate> TreeItemTemplates { get; set; }
        public virtual ICollection<RoleTreeItem> RoleTreeItems { get; set; }
        public virtual TreeItemType TreeItemType { get; set; }
        public virtual ICollection<TreeItem> TreeItems { get; set; }
        public virtual TreeItem ParentTreeItem { get; set; }
    }
}