using System.Collections.Generic;

namespace Socrat.Data.Model
{
    public class Module : Entity
    {
        public Module()
        {
            TreeItems = new HashSet<TreeItem>();
        }

        public string Name { get; set; }
        public string ModuleName { get; set; }
        public virtual ICollection<TreeItem> TreeItems { get; set; }
    }
}