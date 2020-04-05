using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.XtraBars;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Lib.Commands;

namespace Socrat.Startup.Commands
{
    /// <summary>
    /// Построитель главного меню
    /// </summary>
    public static class MenuBuilder
    {
        public static BarItem[] GetItems(BarManager barManager, IMenuCommand cmd)
        {
            List<BarItem> _items = new List<BarItem>();
            BarSubItem _subitem;
            BarButtonItem _item;
            foreach (IMenuCommand _cmd in cmd.Commands)
            {
                switch (_cmd.CommandType)
                {
                    case MenuCommandType.Seporator:
                        break;
                    case MenuCommandType.Group:
                        _subitem = new BarSubItem(barManager, _cmd.Title);
                        if (_cmd.Commands != null && _cmd.Commands.Count > 0)
                            _subitem.AddItems(GetItems(barManager, _cmd));
                        _items.Add(_subitem);
                        break;
                    case MenuCommandType.Item:
                        _item = new BarButtonItem(barManager, _cmd.Title);
                        _item.BindCommand(_cmd);
                        _items.Add(_item);
                        break;
                }
            }

            return _items.ToArray();
        }


        public static List<IMenuCommand> GetItemsFromMenuTree(List<TreeItem> menuTreeItems)
        {
            List<IMenuCommand> _menu = new List<IMenuCommand>();

            IMenuCommand _subMenuItem;
            foreach (TreeItem treeItem in menuTreeItems)
            {
                switch (treeItem.TreeItemType.Enum)
                {
                    case TreeItemTypeEnum.Folder: //папка
                        _subMenuItem = new SubMenuItem { Title = treeItem.Name };
                        _menu.Add(_subMenuItem);
                        if (treeItem.TreeItems != null && treeItem.TreeItems.Count > 0)
                            _subMenuItem.Commands.AddRange(GetItemsFromMenuTree(treeItem.TreeItems.OrderBy(x => x.SortNum).ToList()));
                        break;
                    case TreeItemTypeEnum.Form: //открыть форму
                        if (treeItem.Module != null)
                            _menu.Add(new ItemMenuCommand(treeItem.Name, () => { AppMain.LoadFormTabByName(treeItem.Module.Name, treeItem.Module.Id); }));
                        break;
                    case TreeItemTypeEnum.Module: //открыть модуль
                        if (treeItem.Module != null)
                            _menu.Add(new ItemMenuCommand(treeItem.Name, () => { AppMain.LoadModuleTab(treeItem.Module.Name, treeItem.Module.Id); }));
                        break;
                }
            }

            return _menu;
        }

        public static List<IMenuCommand> GetItemsRole(Role role, ObservableCollection<TreeItem> menuTreeItems)
        {
            List<IMenuCommand> _menu = new List<IMenuCommand>();

            IMenuCommand _subMenuItem;
            foreach (TreeItem treeItem in menuTreeItems.OrderBy(x => x.SortNum))
            {
                if (!role.GetTreeItemAccess(treeItem))
                    continue;

                switch (treeItem.TreeItemType.Enum)
                {
                    case TreeItemTypeEnum.Folder: //папка
                        _subMenuItem = new SubMenuItem { Title = treeItem.Name };
                        _menu.Add(_subMenuItem);
                        if (treeItem.TreeItems != null && treeItem.TreeItems.Count > 0)
                            _subMenuItem.Commands.AddRange(GetItemsRole(role,new ObservableCollection<TreeItem>(treeItem.TreeItems)));
                        break;
                    case TreeItemTypeEnum.Form: //открыть форму
                        if (treeItem.Module != null)
                            _menu.Add(new ItemMenuCommand(treeItem.Name,
                                () => { AppMain.LoadFormTabByName(treeItem.Module.Name, treeItem.Module.Id, role.GetTreeItemReadOnly(treeItem)); }));
                        break;
                    case TreeItemTypeEnum.Module: //открыть модуль
                        if (treeItem.Module != null)
                            _menu.Add(new ItemMenuCommand(treeItem.Name,
                                () => { AppMain.LoadModuleTab(treeItem.Module.Name, treeItem.Module.Id, role.GetTreeItemReadOnly(treeItem)); }));
                        break;
                }
            }

            return _menu;
        }

        public static BarItem[] BuildFromDb(BarManager barManager, Socrat.Core.Entities.Role role)
        {
            List<BarItem> _items = new List<BarItem>();

            MenuTree _menuTree;

            DataHelper.ReloadCollection(role, "RoleTreeItems");
            var _accessedItems = role.RoleTreeItems
                .Where(x => (x.Read ?? false) || (x.Write ?? false))
                .Select(y => y.TreeItem).ToList();

            _menuTree = new MenuTree(_accessedItems);

            IMenuCommand _cmd = new MainMenuCommands();
            _cmd.Commands.Clear();
            List<IMenuCommand> _menuItems = GetItemsRole(role, _menuTree);
            _cmd.Commands.AddRange(_menuItems);
            BarItem[] _barItems = GetItems(barManager, _cmd);

            _items.AddRange(_barItems);
            _menuTree = null;
            return _items.ToArray();
        }
    }
}
