using System;

namespace Socrat.Core.Entities
{
    public class RoleTreeItem : Entity
    {
        //public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid TreeItemId { get; set; }

        private bool? _read;
        public bool? Read
        {
            get { return _read; }
            set { SetField(ref _read, value, () => Read); }
        }

        private bool? _write;
        public bool? Write
        {
            get { return _write; }
            set { SetField(ref _write, value, () => Write); }
        }

        private Role _role;
        public virtual Role Role
        {
            get { return _role; }
            set { SetField(ref _role, value, () => Role); }
        }
        private TreeItem _treeItem;
        public virtual TreeItem TreeItem
        {
            get { return _treeItem; }
            set { SetField(ref _treeItem, value, () => TreeItem); }
        }
        protected override string GetTitle()
        {
            return Role?.Name + " - " + TreeItem?.Name;
        }
    }
}
