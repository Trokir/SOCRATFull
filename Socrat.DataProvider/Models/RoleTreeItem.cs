using System;

namespace Socrat.Data.Model
{
    public class RoleTreeItem : Entity
    {
        public Guid RoleId { get; set; }
        public Guid TreeItemId { get; set; }
        public bool? Read { get; set; }
        public bool? Write { get; set; }
        public virtual Role Role { get; set; }
        public virtual TreeItem TreeItem { get; set; }
    }
}