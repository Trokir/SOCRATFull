using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Model.Users
{
    public class MenuTree: ObservableCollection<TreeItem>
    {
        private List<TreeItem> _itemsList;

        /// <summary>
        /// Построение дерева меню для редактирования (все меню)
        /// </summary>
        /// <param name="itemsList">пункты меню</param>
        public MenuTree(List<TreeItem> itemsList)
        {
            this.CollectionChanged += MenuTree_CollectionChanged;
            _itemsList = itemsList;
            BuildTree();
        }

        private void MenuTree_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (!_watchChanges)
                return;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (TreeItem item in e.NewItems)
                    {
                        if (item != null && !_itemsList.Exists(x => x.Id == item.Id && x.Name == item.Name))
                        {
                            _itemsList.Add(item);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Построение дерева меню для пользователя с учетом его роли
        /// </summary>
        /// <param name="role">роль пользователя</param>
        public MenuTree(IEnumerable<TreeItem> menuItems)
        {
            this.CollectionChanged += MenuTree_CollectionChanged;
            _itemsList = menuItems.ToList();
            BuildTree();
        }

        private bool _watchChanges = false;
        public void BuildTree()
        {
            this.Clear();
            _watchChanges = false;
            foreach (TreeItem treeItem in _itemsList)
            {
                treeItem.TreeItems = new ObservableCollection<TreeItem>(
                    _itemsList
                    .Where(x => x?.ParentTreeItem_Id == treeItem.Id)
                    .OrderBy(x => x.SortNum));
            }
            var _topItems = _itemsList.Where(x => x.ParentTreeItem == null).OrderBy(x => x.SortNum);
            foreach (TreeItem treeItem in _topItems)
            {
                this.Add(treeItem);
            }
            _watchChanges = true;
        }

        public void DeleteMenuItem(Predicate<TreeItem> predicate)
        {
            foreach (TreeItem treeItem in this)
            {
                if (predicate.Invoke(treeItem))
                {
                    if (treeItem.TreeItems == null || treeItem.TreeItems.Count < 1)
                    {
                        this.Remove(treeItem);
                        break;
                    }
                    else
                    {
                        if (treeItem.DeleteChaildItem(predicate))
                            break;
                    }
                }

            }
        }

        public bool CheckMenuItemExists(TreeItem itemSearch)
        {
            bool res = false;
            foreach (TreeItem treeItem in this)
            {
                res = treeItem.CheckItemExists(x => x.Id == itemSearch.Id
                                                    && x.Name == itemSearch.Name
                                                    && x.TreeItemType_Id == itemSearch.TreeItemType_Id);
                if (res)
                    break;
            }
            return res;
        }

        public List<TreeItem> GetAllItemsList()
        {
            //List <TreeItem> _items = new MenuTree();
            //foreach (TreeItem item in this)
            //{
            //    _items.Add(item);
            //    _items.AddRange(item.GetAllChaildItems());
            //}
            //return _items;
            return _itemsList;
        }
    }
}
