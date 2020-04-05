using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxRoleTreeItemEdit : FxBaseSimpleDialog
    {
        public RoleTreeItem RoleTreeItem { get; set; }
        private List<Role> _roles;
        private List<TreeItem> _treeItems;

        public FxRoleTreeItemEdit()
        {
            InitializeComponent();
            Load += FxRoleTreeItemEdit_Load;
        }

        private void FxRoleTreeItemEdit_Load(object sender, EventArgs e)
        {
            _roles = DataHelper.GetAll<Role>();
            lueRole.Properties.DataSource = _roles;

            _treeItems = DataHelper.GetAll<TreeItem>();
            lueTreeItem.Properties.DataSource = _treeItems;
        }

        protected override IEntity GetEntity()
        {
            return RoleTreeItem;
        }

        protected override void SetEntity(IEntity value)
        {
            RoleTreeItem = value as RoleTreeItem;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(lueRole, RoleTreeItem, x => x.RoleId);
            BindEditor(lueTreeItem, RoleTreeItem, x => x.TreeItemId);
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