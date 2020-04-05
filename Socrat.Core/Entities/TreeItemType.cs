using System.Collections.Generic;
using Socrat.Core.Added;
using Socrat.Core.Helpers;

namespace Socrat.Core.Entities
{
    public class TreeItemType : Entity
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }
        private int? _treeItemTypeNum;
        public int? TreeItemTypeNum
        {
            get { return _treeItemTypeNum; }
            set { SetField(ref _treeItemTypeNum, value, () => TreeItemTypeNum); }
        }
        public virtual ICollection<TreeItem> TreeItems { get; set; } = new HashSet<TreeItem>();
        public TreeItemTypeEnum Enum
        {
            get { return EnumHelper<TreeItemTypeEnum>.FromNum(TreeItemTypeNum.Value); }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
