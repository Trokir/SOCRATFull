using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.DataProvider;
using Socrat.Lib;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxRoleTreeItemEdit : FxBaseSimpleDialog
    {
        public Model.Users.RoleTreeItem RoleTreeItem { get; set; }
        private List<Model.Users.Role> _roles;
        private List<Model.Users.TreeItem> _treeItems;

        public FxRoleTreeItemEdit()
        {
            InitializeComponent();
            Load += FxRoleTreeItemEdit_Load;
        }

        private void FxRoleTreeItemEdit_Load(object sender, EventArgs e)
        {
            using (RoleRepository _repo = new RoleRepository())
            {
                _roles = _repo.GetAll().ToList();
            }

            lueRole.Properties.DataSource = _roles;

            using (TreeItemRepository _repo = new TreeItemRepository())
            {
                _treeItems = _repo.GetAll().ToList();
            }

            lueTreeItem.Properties.DataSource = _treeItems;
        }

        protected override IEntity GetEntity()
        {
            return RoleTreeItem;
        }

        protected override void SetEntity(IEntity value)
        {
            RoleTreeItem = value as Model.Users.RoleTreeItem;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(lueRole, RoleTreeItem, x => x.Role_Id);
            BindEditor(lueTreeItem, RoleTreeItem, x => x.TreeItem_Id);
        }

        protected override string GetTitle()
        {
            return "Доступ к пункту меню";
        }

        private void lueRole_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_roles != null && lueRole.EditValue != null && Guid.TryParse(lueRole.EditValue.ToString(), out _id))
            {
                RoleTreeItem.Role = _roles.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void lueTreeItem_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (_treeItems != null && lueTreeItem.EditValue != null && Guid.TryParse(lueTreeItem.EditValue.ToString(), out _id))
            {
                RoleTreeItem.TreeItem = _treeItems.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueRole, lueTreeItem };
        }

        protected override void OnSaveButtonClick()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}