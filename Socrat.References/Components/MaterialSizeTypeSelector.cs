using Socrat.References.Materials;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class MaterialSizeTypeSelector : 
        ButtonAssistantSelector
            <Core.Entities.MaterialSizeType, 
            FxGenericListTable<Core.Entities.MaterialSizeType>,
            FxMaterialSizeTypeEdit>
    {
        public MaterialSizeTypeSelector()
        {
            InitializeComponent();
        }

        protected override Core.Entities.MaterialSizeType GetEntity()
        {
            return MaterialSizeType;
        }

        [Bindable(true)]
        public Core.Entities.MaterialSizeType MaterialSizeType { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => MaterialSizeType);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "MaterialSizeTypeSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
