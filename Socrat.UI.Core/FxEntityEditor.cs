using System;
using Socrat.Core;


namespace Socrat.UI.Core
{
    public partial class FxEntityEditor : FxBaseEditForm
    {
        private IEntity _Entity { get; set; }
        protected override IEntity GetEntity()
        {
            return (IEntity)_Entity;
        }
        protected override void SetEntity(IEntity value)
        {
            _Entity = value;
        }

        public FxEntityEditor()
        {
            InitializeComponent();
            Load += FxMemoView_Load;
        }

        private void FxMemoView_Load(object sender, EventArgs e)
        {
            propertyGridControl.SelectedObject = Entity;
        }
    }
}