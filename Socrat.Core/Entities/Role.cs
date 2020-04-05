using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class Role : Entity, INamedEntity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        public virtual ObservableCollection<RoleTreeItem> RoleTreeItems { get; set; }
        public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
        public bool GetTreeItemReadOnly(TreeItem treeItem)
        {
            bool res = false;
            var rti = RoleTreeItems?.FirstOrDefault(x => x.TreeItem.Id == treeItem.Id);
            if (rti != null)
                res = rti.Read.Value && !rti.Write.Value;
            return res;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool GetTreeItemAccess(TreeItem treeItem)
        {
            bool res = false;
            var rti = RoleTreeItems?.FirstOrDefault(x => x.TreeItem.Id == treeItem.Id);
            if (rti != null)
                res =(rti.Write ?? false ) || (rti.Read ?? false);
            return res;
        }
    }
}
