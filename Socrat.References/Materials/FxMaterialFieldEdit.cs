using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialFieldEdit : FxBaseSimpleDialog
    {
        public MaterialField MaterialField { get; set; }
        private CxFieldValues _cxFieldValues;

        public FxMaterialFieldEdit()
        {
            InitializeComponent();
            InitFieldsValues();
        }

        protected override IEntity GetEntity()
        {
            return MaterialField;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialField = value as MaterialField;
            _cxFieldValues.Field = MaterialField?.Field;
        }

        private void InitFieldsValues()
        {
            _cxFieldValues = new CxFieldValues();
            _cxFieldValues.Field = MaterialField?.Field;
            _cxFieldValues.DependedSaving = true;
            pcValues.Controls.Add(_cxFieldValues);
            _cxFieldValues.Dock = DockStyle.Fill;
            _cxFieldValues.DialogOutput += _DialogOutput;
        }

        private void _DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ teName};
        } 

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, MaterialField.Field, x => x.Name);
            BindEditor(ceList, MaterialField.Field, x => x.IsFixed);
        }
    }
}