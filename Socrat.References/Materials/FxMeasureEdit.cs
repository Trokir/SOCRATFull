using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    //todo: не работает ввод кода
    public partial class FxMeasureEdit : FxBaseSimpleDialog
    {
        public Measure Measure { get; set; }

        public FxMeasureEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return Measure;
        }

        protected override void SetEntity(IEntity value)
        {
            Measure = value as Measure;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, Measure, x => x.Name);
            BindEditor(seCode, Measure, x => x.OkeiCode);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> {teName, seCode };
        }
    }
}