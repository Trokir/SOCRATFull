using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Contact
{
    public partial class FxContactTypeEditor : FxBaseSimpleDialog
    {
        public ContactType ContactType { get; set; }

        public FxContactTypeEditor()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", ContactType, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        protected override void SetEntity(IEntity value)
        {
            ContactType = value as ContactType;
        }

        protected override IEntity GetEntity()
        {
            return ContactType;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }
    }
}