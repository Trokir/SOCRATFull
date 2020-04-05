using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Division
{
    public partial class FxWorkPositionEdit : FxBaseSimpleDialog
    {
        public WorkPosition WorkPosition { get; set; }

        public FxWorkPositionEdit()
        {
            InitializeComponent();

        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", WorkPosition, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void SetEntity(IEntity value)
        {
            WorkPosition = value as WorkPosition;
        }

        protected override IEntity GetEntity()
        {
            return WorkPosition;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }
    }
}