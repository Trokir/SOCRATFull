using Socrat.Core.Entities;
using Socrat.References.Customer;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Socrat.References.Components
{
    [Bindable(true)]
    public class CustomerSelector : 
        ButtonAssistantSelector
            <Core.Entities.Customer, 
            FxGenericListTable<Core.Entities.Customer>,
            FxCustomerEdit>
    {

        protected override Core.Entities.Customer GetEntity()
        {
            return Customer;
        }

        [Bindable(true)]
        public Core.Entities.Customer Customer { get; set; }

        protected override void BindingData()
        {
            base.BindingData();
            Assistant.BindProperty(Assistant.Obj, (x) => Customer);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DivisionSelector
            // 
            this.Name = "CustomerSelector";
            this.Size = new System.Drawing.Size(297, 23);
            this.ResumeLayout(false);

        }
    }
}
