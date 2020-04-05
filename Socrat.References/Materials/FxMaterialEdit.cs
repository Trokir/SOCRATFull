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
    public partial class FxMaterialEdit : FxBaseSimpleDialog
    {
        public Material Material { get; set; }
        public List<MaterialType> MaterialGroups;
        private CxMaterialSpecProperties _cxMaterialSpecProperties;
        private CxMaterialFields _cxMaterialFields;
        private CxMaterialTradeMarks cxMaterialTradeMarks;

        public FxMaterialEdit()
        {
            InitializeComponent();
            InitSpecProps();
            InitFields();
            InitTradeMarks();
            Load += FxMatrialTypeEdit_Load;
        }

        private void InitTradeMarks()
        {
            cxMaterialTradeMarks = new CxMaterialTradeMarks();
            cxMaterialTradeMarks.Material = Material;
            cxMaterialTradeMarks.DependedSaving = true;
            cxMaterialTradeMarks.DialogOutput += CxMaterialSpecProperties_DialogOutput;
            pcTradeMarks.Controls.Add(cxMaterialTradeMarks);
            cxMaterialTradeMarks.Dock = DockStyle.Fill;
        }

        protected override void SetReadOnly(bool value)
        {
            base.SetReadOnly(value);
            if (_cxMaterialFields != null)
                _cxMaterialFields.ReadOnly = value;
            if (_cxMaterialSpecProperties != null)
                _cxMaterialSpecProperties.ReadOnly = value;
        }

        private void FxMatrialTypeEdit_Load(object sender, System.EventArgs e)
        {
            MaterialGroups = DataHelper.GetAll<MaterialType>();
            lueSubtype.Properties.DataSource = MaterialGroups;
        }

        protected override Socrat.Core.IEntity GetEntity()
        {
            return Material;
        }

        protected override void SetEntity(Socrat.Core.IEntity value)
        {
            Material = value as Material;
            _cxMaterialSpecProperties.Material = this.Material;
            _cxMaterialFields.Material = this.Material;
            cxMaterialTradeMarks.Material = this.Material;
        }

        private void lueSubtype_EditValueChanged(object sender, System.EventArgs e)
        {
            Guid _id;
            if (MaterialGroups != null && lueSubtype.EditValue != null && Guid.TryParse(lueSubtype.EditValue.ToString(), out _id))
            {
                Material.MaterialType = MaterialGroups.FirstOrDefault(x => x.Id == _id);
            }
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Material, x => x.Name);
            BindEditor(teEnumCode, Material, x => x.EnumCode);
            lueSubtype.EditValue = Material?.MaterialType?.Id;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, lueSubtype};
        }

        private void InitSpecProps()
        {
            _cxMaterialSpecProperties = new CxMaterialSpecProperties();
            _cxMaterialSpecProperties.Material = this.Material;
            _cxMaterialSpecProperties.DependedSaving = true;
            pcSpecProps.Controls.Add(_cxMaterialSpecProperties);
            _cxMaterialSpecProperties.Dock = DockStyle.Fill;
            _cxMaterialSpecProperties.DialogOutput += CxMaterialSpecProperties_DialogOutput;
        }


        private void InitFields()
        {
            _cxMaterialFields = new CxMaterialFields();
            _cxMaterialFields.Material = this.Material;
            _cxMaterialFields.DependedSaving = true;
            pcFields.Controls.Add(_cxMaterialFields);
            _cxMaterialFields.Dock = DockStyle.Fill;
            _cxMaterialFields.DialogOutput += CxMaterialSpecProperties_DialogOutput;
        }

        private void CxMaterialSpecProperties_DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }
    }
}