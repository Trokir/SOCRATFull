using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.References.Processings;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceProcessingEdit : FxBaseSimpleDialog
    {
        public PriceProcessing PriceProcessing { get; set; }
        private IPriceService _priceService;
        public FxPriceProcessingEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
            SaveButtonClick += FxPriceProcessingEdit_SaveButtonClick; ;
        }

        private void FxPriceProcessingEdit_SaveButtonClick(object sender, EventArgs e)
        {
            PriceProcessing.EditDate = DateTime.Now;
        }

        protected override IEntity GetEntity()
        {
            return PriceProcessing;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceProcessing = value as PriceProcessing;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beProcessing, bePricePeriod };
        }

        protected override void BindData()
        {
            base.BindData();

            beProcessing.DataBindings.Clear();
            beProcessing.DataBindings.Add("EditValue", PriceProcessing, "Processing", true,
                DataSourceUpdateMode.OnPropertyChanged);

            bePricePeriod.DataBindings.Clear();
            bePricePeriod.DataBindings.Add("EditValue", PriceProcessing, "PricePeriod", true,
                DataSourceUpdateMode.OnPropertyChanged);

            BindEditor(seDiscount, PriceProcessing, x => x.Discount);
            BindEditor(seDelta, PriceProcessing, x => x.Delta);

        }

        private void beProcessing_Click(object sender, EventArgs e)
        {
            FxProcessings processings = new FxProcessings();
            processings.SetSingleSelectMode(PriceProcessing.Processing);
            DialogResult dialogResult = processings.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && processings.SelectedItem != null)
                PriceProcessing.Processing = processings.SelectedItem as Processing;
        }

        private void bePricePeriod_Click(object sender, EventArgs e)
        {
            FxPricePeriods pricePeriods = new FxPricePeriods();
            pricePeriods.SetSingleSelectMode(PriceProcessing.PricePeriod);
            DialogResult dialogResult = pricePeriods.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && pricePeriods.SelectedItem != null)
                PriceProcessing.PricePeriod = pricePeriods.SelectedItem as PricePeriod;
        }
    }
}