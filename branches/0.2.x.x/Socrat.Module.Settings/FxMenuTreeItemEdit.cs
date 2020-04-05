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
using Socrat.Model.Users;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxMenuTreeItemEdit : FxBaseSimpleDialog
    {
        public Model.Users.TreeItem TreeItem { get; set; }
        private List<Model.Users.TreeItemType> TreeItemTypes;
        private List<Model.Users.Module> _modules;

        public FxMenuTreeItemEdit()
        {
            InitializeComponent();
            Load += FxMenuTreeItemEdit_Load;
        }

        private void FxMenuTreeItemEdit_Load(object sender, EventArgs e)
        {
        }

        protected override void BindData()
        {
            base.BindData();

            using (TreeItemTypeRepository _repo = new TreeItemTypeRepository())
            {
                TreeItemTypes = _repo.GetAll().ToList();
                lueItemType.Properties.DataSource = TreeItemTypes;
            }

            using (ModuleRepository _repo = new ModuleRepository())
            {
                _modules = _repo.GetAll().ToList();
                lueModule.Properties.DataSource = _modules;
            }

            BindEditor(lueItemType, TreeItem, x => x.TreeItemType_Id);
            BindEditor(teName, TreeItem, x => x.Name);
            BindEditor(lueModule, TreeItem, x => x.Module_Id);
            BindEditor(seSortNum, TreeItem, x => x.SortNum);
        }

        protected override IEntity GetEntity()
        {
            return TreeItem;
        }

        protected override void SetEntity(IEntity value)
        {
            TreeItem = value as Model.Users.TreeItem;
        }

        protected override string GetTitle()
        {
            return "Пункт меню";
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueItemType, teName};
        }

        private void lueItemType_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueItemType.EditValue != null && Guid.TryParse(lueItemType.EditValue.ToString(), out _id))
            {
                TreeItem.TreeItemType = TreeItemTypes.FirstOrDefault(x => x.Id == _id);
            }
        }

        private void lueModule_EditValueChanged(object sender, EventArgs e)
        {
            Guid _id;
            if (lueModule.EditValue != null && Guid.TryParse(lueModule.EditValue.ToString(), out _id))
            {
                TreeItem.Module = _modules.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}