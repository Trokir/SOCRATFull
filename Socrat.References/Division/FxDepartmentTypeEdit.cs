using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Division
{
    public partial class FxDepartmentTypeEdit : FxBaseSimpleDialog
    {
        public DepartmentType DepartmentType { get; set; }

        public FxDepartmentTypeEdit()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return DepartmentType;
        }

        protected override void SetEntity(IEntity value)
        {
            DepartmentType = value as DepartmentType;
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        protected override void BindData()
        {
            base.BindData();
            teName.DataBindings.Clear();
            teName.DataBindings.Add("EditValue", DepartmentType, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}