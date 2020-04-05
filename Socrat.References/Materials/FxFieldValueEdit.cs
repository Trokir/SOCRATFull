using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxFieldValueEdit : FxBaseSimpleDialog
    {
        public FieldValue FieldValue { get; set; }

        public FxFieldValueEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return FieldValue;
        }

        protected override void SetEntity(IEntity value)
        {
            FieldValue = value as FieldValue;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teValue, FieldValue, x => x.Value);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit>{ teValue };
        }
    }
}