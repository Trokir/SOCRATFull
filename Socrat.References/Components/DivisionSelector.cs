using Socrat.Core.Entities;
using Socrat.References.Division;
using System.ComponentModel;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class DivisionSelector : 
        ButtonAssistantSelector
            <Core.Entities.Division, 
            FxGenericListTable<Core.Entities.Division>, 
            FxDivisionEdit>
    {

        protected override Core.Entities.Division GetEntity()
        {
            return Division;
        }

        [Bindable(true)]
        public Core.Entities.Division Division { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(this, (x) => Division);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "DivisionSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
