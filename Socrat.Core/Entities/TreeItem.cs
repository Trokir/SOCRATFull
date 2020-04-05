using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Socrat.Core.Entities
{
    public class TreeItem : Entity
    {
        public TreeItem()
        {
            TreeItems = new ObservableCollection<TreeItem>();
            TreeItems.CollectionChanged += TreeItems_CollectionChanged;
        }

        private void TreeItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (TreeItem item in e.NewItems)
                    item.Changed = true;
            if (e.Action == NotifyCollectionChangedAction.Add)
                if (e.NewItems.Contains(this))
                    throw new Exception(" олизи€ - ссылка на самого себ€");
            Changed = true;
        }
        public Guid TreeItemTypeId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value, () => Name); }
        }

        public Guid? ParentTreeItemId { get; set; }
        public Guid? ModuleId { get; set; }

        private short? _sortNum;
        public short? SortNum
        {
            get { return _sortNum; }
            set { SetField(ref _sortNum, value, () => SortNum); }
        }

        private Module _module;
        public virtual Module Module
        {
            get { return _module; }
            set
            {
                if (value != null && string.IsNullOrEmpty(Name))
                    Name = value.Title;
                SetField(ref _module, value, () => Module);
            }
        }
        public virtual ICollection<RoleTreeItem> RoleTreeItems { get; set; } = new HashSet<RoleTreeItem>();

        private TreeItemType _treeItemType;
        public virtual TreeItemType TreeItemType
        {
            get { return _treeItemType; }
            set { SetField(ref _treeItemType, value, () => TreeItemType); }
        }
        public virtual ObservableCollection<TreeItem> TreeItems { get; set; }

        [ParentItem]
        private TreeItem _parentTreeItem;
        public virtual TreeItem ParentTreeItem
        {
            get { return _parentTreeItem; }
            set { SetField(ref _parentTreeItem, value, () => ParentTreeItem); }
        }

        public bool DeleteChaildItem(Predicate<TreeItem> predicate)
        {
            bool res = false;
            if (TreeItems != null)
                foreach (TreeItem treeItem in TreeItems)
                {
                    res = predicate.Invoke(treeItem);
                    if (res)
                    {
                        TreeItems.Remove(treeItem);
                        break;
                    }
                    else
                        res = treeItem.DeleteChaildItem(predicate);

                }
            return res;
        }
        public bool CheckItemExists(Predicate<TreeItem> predicate)
        {
            bool res = predicate.Invoke(this);
            if (!res)
            {
                if (TreeItems != null)
                    foreach (TreeItem treeItem in TreeItems)
                    {
                        res = predicate.Invoke(treeItem) || treeItem.CheckItemExists(predicate);
                        if (res)
                            break;
                    }
            }
            return res;
        }

        /// <summary>
        /// ѕризнак, что узел дерева при отрисовке уже проиницирован
        /// </summary>
        public bool NodeInited { get; set; }

        public bool ItemExists(Guid id)
        {
            return Id == id
                   || (TreeItems.Count(x => x.ItemExists(id)) > 0);
        }

        public IEnumerable<TreeItem> GetAllChaildItems()
        {
            List<TreeItem> _items = new List<TreeItem>();
            if (TreeItems != null)
                foreach (TreeItem treeItem in TreeItems)
                {
                    _items.Add(treeItem);
                    _items.AddRange(treeItem.GetAllChaildItems());
                }
            return _items;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
