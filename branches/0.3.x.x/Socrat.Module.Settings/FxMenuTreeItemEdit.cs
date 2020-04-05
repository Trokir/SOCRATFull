using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxMenuTreeItemEdit : FxBaseSimpleDialog
    {
        public TreeItem TreeItem { get; set; }
        private List<TreeItemType> TreeItemTypes;
        private List<Core.Entities.Module> _modules;

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

            TreeItemTypes = DataHelper.GetAll<TreeItemType>();
            lueItemType.Properties.DataSource = TreeItemTypes;
            _modules = DataHelper.GetAll<Core.Entities.Module>();
            lueModule.Properties.DataSource = _modules;

            BindEditor(teName, TreeItem, x => x.Name);
            BindEditor(seSortNum, TreeItem, x => x.SortNum);

            lueItemType.EditValue = TreeItem?.TreeItemType?.Id;
            lueModule.EditValue = TreeItem?.Module?.Id;
        }

        protected override IEntity GetEntity()
        {
            return TreeItem;
        }

        protected override void SetEntity(IEntity value)
        {
            TreeItem = value as TreeItem;
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