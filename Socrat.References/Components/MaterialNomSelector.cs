using Socrat.References.Materials;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class MaterialNomSelector : 
        ButtonAssistantSelector
            <Core.Entities.MaterialNom, 
            FxGenericListTable<Core.Entities.MaterialNom>,
            FxMaterialNomEdit>
    {
        public MaterialNomSelector()
        {
            InitializeComponent();
        }

        protected override Core.Entities.MaterialNom GetEntity()
        {
            return MaterialNom;
        }

        [Bindable(true)]
        public Core.Entities.MaterialNom MaterialNom { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => MaterialNom);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "MaterialNomSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
