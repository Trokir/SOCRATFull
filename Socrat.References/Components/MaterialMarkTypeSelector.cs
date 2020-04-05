using Socrat.References.Materials;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class MaterialMarkTypeSelector : 
        ButtonAssistantSelector
            <Core.Entities.MaterialMarkType, 
            FxGenericListTable<Core.Entities.MaterialMarkType>,
            FxMaterialMarkTypeEdit>
    {
        public MaterialMarkTypeSelector()
        {
            InitializeComponent();
        }

        protected override Core.Entities.MaterialMarkType GetEntity()
        {
            return MaterialMarkType;
        }

        [Bindable(true)]
        public Core.Entities.MaterialMarkType MaterialMarkType { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => MaterialMarkType);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "MaterialMarkTypeSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
