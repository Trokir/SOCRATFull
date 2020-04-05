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
using Socrat.DataProvider;
using Socrat.References.Order;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceSlozEdit : FxBaseSimpleDialog
    {
        private Core.Entities.Price _price;
        public PriceSloz PriceSloz { get; set; }
        private IPriceService _priceService;
        public FxPriceSlozEdit()
        {
            Init();
        }

        public FxPriceSlozEdit(Core.Entities.Price price)
        {
            _price = price;
            Init();
        }

        private void Init()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void SaveButtonClicked()
        {
            IRepository<PriceSloz> repository = DataHelper.GetRepository<PriceSloz>();
            PriceSloz.Edit = DateTime.Now;
            repository.Save(PriceSloz);
            PriceSloz.Changed = false;
            base.SaveButtonClicked();
        }

        protected override IEntity GetEntity()
        {
            return PriceSloz;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceSloz = value as PriceSloz;

            PriceSloz.Price = _price;
            PriceSloz.PriceId = _price.Id;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beSlozType, teValue, teDiscount, teDelta };
        }

        protected override void BindData()
        {
            base.BindData();

            beSlozType.DataBindings.Clear();
            beSlozType.DataBindings.Add("EditValue", PriceSloz, "SlozType", true,
                DataSourceUpdateMode.OnPropertyChanged);

            BindEditor(teValue, PriceSloz, x => x.PriceSlozName);

            BindEditor(teDiscount, PriceSloz, x => x.Discount);

            BindEditor(teDelta, PriceSloz, x => x.Delta);
        }

        private void bePrice_Click(object sender, EventArgs e)
        {
            FxPrices prices = new FxPrices();
            prices.SetSingleSelectMode(PriceSloz.Price);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceSloz.Price = prices.SelectedItem as Core.Entities.Price;
        }

        private void beSlozType_Click(object sender, EventArgs e)
        {
            FxSlozTypes prices = new FxSlozTypes();
            prices.SetSingleSelectMode(PriceSloz.SlozType);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceSloz.SlozType = prices.SelectedItem as Core.Entities.SlozType;
        }
    }
}