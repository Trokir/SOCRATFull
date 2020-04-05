using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Order
{
    public partial class FxOrderStatusEditor : FxBaseSimpleDialog
    {
        public OrderStatus OrderStatus { get; set; }

        public FxOrderStatusEditor()
        {
            InitializeComponent();
        }

        protected override IEntity GetEntity()
        {
            return OrderStatus;
        }

        protected override void SetEntity(IEntity value)
        {
            OrderStatus = value as OrderStatus;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, OrderStatus, x => x.Name);
            BindEditor(seNum, OrderStatus, x => x.OrderNum);
            BindEditor(meDesc, OrderStatus, x => x.Description);
            BindEditor(meMessage, OrderStatus, x => x.CustomerMessage);
            ceColor.Color = OrderStatus.GetColor();
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName };
        }

        private void ceColor_ColorChanged(object sender, System.EventArgs e)
        {
            OrderStatus.SetColor(ceColor.Color);
        }
    }
}
