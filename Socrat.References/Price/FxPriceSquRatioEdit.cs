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
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceSquRatioEdit : FxBaseSimpleDialog
    {
        private IPriceService _priceService;
        private Core.Entities.Price _price;
        public PriceSquRatio PriceSquRatio { get; set; }

        protected override IEntity GetEntity()
        {
            return PriceSquRatio;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceSquRatio = value as PriceSquRatio;

            PriceSquRatio.Price = _price;
            PriceSquRatio.PriceId = _price.Id;
        }

        protected override string GetTitle()
        {
            return "Наценка за площадь изделия";
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { bePrice };
        }
        public FxPriceSquRatioEdit()
        {
            Init();
        }

        public FxPriceSquRatioEdit(Core.Entities.Price price)
        {
            _price = price;
            Init();
        }


        protected override void SaveButtonClicked()
        {
            IRepository<PriceSquRatio> repository = DataHelper.GetRepository<PriceSquRatio>();
            PriceSquRatio.EditDate = DateTime.Now;
            repository.Save(PriceSquRatio);
            PriceSquRatio.Changed = false;
            base.SaveButtonClicked();
        }

        private void Init()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teSqu, PriceSquRatio, x => x.Squ);
            BindEditor(teRatio, PriceSquRatio, x => x.Ratio);
            bePrice.DataBindings.Clear();
            bePrice.DataBindings.Add("EditValue", PriceSquRatio, "Price", true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void bePrice_Click(object sender, EventArgs e)
        {
            FxPrices prices = new FxPrices();
            prices.SetSingleSelectMode(PriceSquRatio.Price);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceSquRatio.Price = prices.SelectedItem as Core.Entities.Price;
        }
    }
}