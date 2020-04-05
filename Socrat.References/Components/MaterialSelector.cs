using Socrat.References.Materials;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class MaterialSelector : 
        ButtonAssistantSelector
            <Core.Entities.Material, 
            FxGenericListTable<Core.Entities.Material>,
            FxMaterialEdit>
    {
        public MaterialSelector()
        {
            InitializeComponent();
        }

        protected override Core.Entities.Material GetEntity()
        {
            return Material;
        }

        [Bindable(true)]
        public Core.Entities.Material Material { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => Material);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "MaterialSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
