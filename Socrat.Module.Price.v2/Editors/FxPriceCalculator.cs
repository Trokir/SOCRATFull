using Socrat.UI.Core;
using System;

namespace Socrat.Module.Price
{
    public partial class FxPriceCalculator : FxBaseSimpleDialog
    {
        public FxPriceCalculator()
        {
            InitializeComponent();
            ButtonsPanelVisible = false;
        }

        private void DimensionsChanged(object sender, EventArgs e)
        {
            teSquare.Text = $"{(ceHeight.Value * ceWidth.Value):f4}";
        }

        private void ceQuantity_ValueChanged(object sender, EventArgs e)
        {
            teSum.Text = $"{ceQuantity.Value * decimal.Parse(tePrice.Text):f2}";
        }

        private void teSquare_TextChanged(object sender, EventArgs e)
        {
            tePrice.Text = $"{Calculate(Decimal.Parse(teSquare.Text)):f2}";
        }

        private decimal Calculate(decimal square)
        {

            return 0;
        }
    }
}
