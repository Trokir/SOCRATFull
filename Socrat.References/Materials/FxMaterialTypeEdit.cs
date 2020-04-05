using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Materials
{
    public partial class FxMaterialTypeEdit : FxBaseSimpleDialog
    {
        public MaterialType MaterialType { get; set; }

        protected override IEntity GetEntity()
        {
            return MaterialType;
        }

        protected override void SetEntity(IEntity value)
        {
            MaterialType = value as MaterialType;
        }

        public FxMaterialTypeEdit()
        {
            InitializeComponent();
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, MaterialType, x => x.Name);
            flaggedProductionTypeEditor.DataBindings.Clear();
            flaggedProductionTypeEditor.DataBindings
                .Add("FlaggedProductionType", MaterialType, "FlaggedProductionType");
        }
    }
}