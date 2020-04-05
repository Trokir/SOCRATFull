using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{

    public partial class FxMaterialMarkTypeEdit : FxBaseSimpleDialog
    {
        public MaterialMarkType MaterialMarkType { get; set; }
        public List<Material> MaterialTypes { get; set; }
        private CxMaterialSizeTypes cxMaterialSizeTypes;

        public FxMaterialMarkTypeEdit()
        {
            InitializeComponent();
        }

        private void InitSizes()
        {
            cxMaterialSizeTypes = new CxMaterialSizeTypes();
            cxMaterialSizeTypes.MaterialMarkType = MaterialMarkType;
            cxMaterialSizeTypes.DependedSaving = true;
            cxMaterialSizeTypes.DialogOutput += CxMaterialSizeTypes_DialogOutput;
            pcSizes.Controls.Add(cxMaterialSizeTypes);
            cxMaterialSizeTypes.Dock = DockStyle.Fill;

        }

        private void CxMaterialSizeTypes_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }

        protected override IEntity GetEntity()
        {
            return MaterialMarkType;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialMarkType = value as MaterialMarkType;
        }

        protected override void BindData()
        {
            InitSizes();

            MaterialTypes = DataHelper.GetAll<Material>();
            lueMaterialType.Properties.DataSource = MaterialTypes;

            base.BindData();
            BindEditor(teName, MaterialMarkType, x => x.Name);
            BindEditor(teMark, MaterialMarkType, x => x.Mark);
            BindEditor(teGostMark, MaterialMarkType, x => x.GostMark);

            if (MaterialMarkType.Material == null)
                lueMaterialType.EditValue = MaterialTypes?.FirstOrDefault()?.Id;
            else
                lueMaterialType.EditValue = MaterialMarkType?.Material?.Id;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { lueMaterialType, teName};
        }

        private void lueMaterialType_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (lueMaterialType.EditValue != null && Guid.TryParse(lueMaterialType.EditValue.ToString(), out _id))
            {
                MaterialMarkType.Material = MaterialTypes.FirstOrDefault(x => x.Id == _id);
            }
        }
    }
}