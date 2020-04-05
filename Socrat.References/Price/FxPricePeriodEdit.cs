using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPricePeriodEdit : FxBaseSimpleDialog
    {
        public PricePeriod PricePeriod { get; set; }
        private IPriceService _priceService;
        public FxPricePeriodEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return PricePeriod;
        }

        protected override void SetEntity(IEntity value)
        {
            PricePeriod = value as PricePeriod;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { bePrice, deDateBegin, teBaseSpo, teBaseSpo };
        }

        private void bePrice_Click(object sender, System.EventArgs e)
        {
            FxPrices prices = new FxPrices();
            prices.SetSingleSelectMode(PricePeriod.Price);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PricePeriod.Price = prices.SelectedItem as Core.Entities.Price;
        }
        protected override void BindData()
        {
            base.BindData();

            bePrice.DataBindings.Clear();
            bePrice.DataBindings.Add("EditValue", PricePeriod, "Price", true,
                DataSourceUpdateMode.OnPropertyChanged);

            BindEditor(deDateBegin, PricePeriod, x => x.DateBegin);
            BindEditor(teBaseSpo, PricePeriod, x => x.BaseSpo);
            BindEditor(teBaseSpd, PricePeriod, x => x.BaseSpd);
        }
    }
}