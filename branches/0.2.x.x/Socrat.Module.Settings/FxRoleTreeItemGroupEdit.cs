using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Model.Users;
using Socrat.UI.Core;
using RoleTreeItem = Socrat.Model.Users.RoleTreeItem;
using TreeItem = Socrat.DataProvider.TreeItem;

namespace Socrat.Module.Settings
{
    public partial class FxRoleTreeItemGroupEdit : FxBaseForm
    {
        public Model.Users.Role Role { get; set; }
        public MenuTree MenuTree { get; set; }
        private List<RoleTreeItem> _roleTreeItems;

        public FxRoleTreeItemGroupEdit()
        {
            InitializeComponent();
            Load += FxRoleTreeItemGroupAdd_Load;
        }

        private void FxRoleTreeItemGroupAdd_Load(object sender, EventArgs e)
        {
            using (TreeItemRepository _repo = new TreeItemRepository())
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
            List<Model.Users.TreeItem> _treeItems = MenuTree.GetAllItemsList();
            RoleTreeItem _roleTreeItem;
            foreach (Model.Users.TreeItem treeItem in _treeItems)
            {
                _roleTreeItem = Role.RoleTreeItems.FirstOrDefault(x => x.TreeItem?.Id == treeItem.Id);
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
            using (RoleTreeItemRepository _repo = new RoleTreeItemRepository())
            {
                foreach (RoleTreeItem roleTreeItem in _roleTreeItems)
                {
                    if (roleTreeItem.Changed)
                    {
                        if (roleTreeItem.Write || roleTreeItem.Read)
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