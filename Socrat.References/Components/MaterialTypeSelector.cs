using Socrat.References.Materials;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class MaterialTypeSelector : 
        ButtonAssistantSelector
            <Core.Entities.MaterialType, 
            FxGenericListTable<Core.Entities.MaterialType>,
            FxMaterialTypeEdit>
    {
        public MaterialTypeSelector()
        {
            InitializeComponent();
        }

        protected override Core.Entities.MaterialType GetEntity()
        {
            return MaterialType;
        }

        [Bindable(true)]
        public Core.Entities.MaterialType MaterialType { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => MaterialType);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "MaterialTypeSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
