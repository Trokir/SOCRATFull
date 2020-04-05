using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Role : Entity
    {
        public Role()
        {
            RoleTreeItems = new HashSet<RoleTreeItem>();
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public virtual ICollection<RoleTreeItem> RoleTreeItems { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}