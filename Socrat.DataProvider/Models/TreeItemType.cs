using System.Collections.Generic;
using Socrat.Common.Enums;

namespace Socrat.Data.Model
{
    public class TreeItemType : Entity
    {
        public TreeItemType()
        {
            TreeItems = new HashSet<TreeItem>();
        }

        public string Name { get; set; }
        public TreeItemTypeEnum? TreeItemTypeNum { get; set; }
        public virtual ICollection<TreeItem> TreeItems { get; set; }
    }
}