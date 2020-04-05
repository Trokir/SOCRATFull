using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceSelectTypeEdit : FxBaseSimpleDialog
    {
        public PriceSelectType PriceSelectType { get; set; }
        private IPriceService _priceService;
        public FxPriceSelectTypeEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return PriceSelectType;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceSelectType = value as PriceSelectType;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { bePrice, bePriceType };
        }

        private void bePrice_Click(object sender, EventArgs e)
        {
            FxPrices prices = new FxPrices();
            prices.SetSingleSelectMode(PriceSelectType.Price);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceSelectType.Price = prices.SelectedItem as Core.Entities.Price;
        }

        private void bePriceType_Click(object sender, EventArgs e)
        {
            FxPriceTypes priceTypes = new FxPriceTypes();
            priceTypes.SetSingleSelectMode(PriceSelectType.PriceType);
            DialogResult dialogResult = priceTypes.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && priceTypes.SelectedItem != null)
                PriceSelectType.PriceType = priceTypes.SelectedItem as Core.Entities.PriceType;
        }

        

        protected override void BindData()
        {
            base.BindData();

            bePrice.DataBindings.Clear();
            bePrice.DataBindings.Add("EditValue", PriceSelectType, "Price", true,
                DataSourceUpdateMode.OnPropertyChanged);

            bePriceType.DataBindings.Clear();
            bePriceType.DataBindings.Add("EditValue", PriceSelectType, "PriceType", true,
                DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}