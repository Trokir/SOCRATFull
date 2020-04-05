using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils.Extensions;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.Core.Added;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxRoleTreeItemGroupEdit : FxBaseForm
    {
        public Role Role { get; set; }
        public MenuTree MenuTree { get; set; }
        private List<RoleTreeItem> _roleTreeItems;

        public FxRoleTreeItemGroupEdit()
        {
            InitializeComponent();
            Load += FxRoleTreeItemGroupAdd_Load;
        }

        private void FxRoleTreeItemGroupAdd_Load(object sender, EventArgs e)
        {
            using (Socrat.Core.IRepository<TreeItem> _repo = DataHelper.GetRepository<TreeItem>())
            {
                MenuTree = new MenuTree(_repo.GetAll().ToList());
            }

            BuildRoleTreeItms();
            tlRoleTreeItems.DataSource = _roleTreeItems;

            Text += ". Роль: " + Role.Name;
        }

        private void BuildRoleTreeItms()
        {
            _roleTreeItems = new List<RoleTreeItem>();
            List<TreeItem> _treeItems = MenuTree.GetAllItemsList();
            RoleTreeItem _roleTreeItem;
            foreach (TreeItem treeItem in _treeItems)
            {
                _roleTreeItem = Role?.RoleTreeItems.FirstOrDefault(x => x.TreeItem?.Id == treeItem.Id);
                if (_roleTreeItem == null)
                {
                    _roleTreeItem = new RoleTreeItem();
                    _roleTreeItem.Role = Role;
                    _roleTreeItem.TreeItem = treeItem;
                    _roleTreeItem.Changed = false;
                }
                _roleTreeItems.Add(_roleTreeItem);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (Socrat.Core.IRepository<RoleTreeItem> _repo = DataHelper.GetRepository<RoleTreeItem>())
            {
                foreach (RoleTreeItem roleTreeItem in _roleTreeItems)
                {
                    if (roleTreeItem.Changed)
                    {
                        if (roleTreeItem.Write.Value || roleTreeItem.Read.Value)
                        {
                            _repo.Save(roleTreeItem);
                           if (Role.RoleTreeItems.Count(x => x.Id == roleTreeItem.Id)<1)
                               Role.RoleTreeItems.Add(roleTreeItem);
                        }
                        else if (roleTreeItem.Id != Guid.Empty)
                        {
                            _repo.Delete(roleTreeItem.Id);
                            int _indx = Role.RoleTreeItems.IndexOf(x => x.Id == roleTreeItem.Id);
                            Role.RoleTreeItems.RemoveAt(_indx);
                        }
                    }
                }
            }
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}