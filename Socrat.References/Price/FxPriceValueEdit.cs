using System;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Added;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.References.Materials;
using Socrat.UI.Core;
using Socrat.Core.Repositories.Abstract;

namespace Socrat.References.Price
{
    public partial class FxPriceValueEdit : FxBaseSimpleDialog
    {
        public PriceValue PriceValue { get; set; }
        public bool Added { get; set; } = false;
        public FxPriceValueEdit()
        {
            InitializeComponent();
        }

        protected override void SaveButtonClicked()
        {
            if (Added)
            {
                PriceValue.PricePeriodId = PriceValue.PricePeriod.Id;
                PriceValue.PricePeriod = null;
            }
            else
            {
                //ISocratRepository<PriceValue> repository = CommonSocratRepository.GetInstance<PriceValue>();
                //PriceValue priceVal = repository.GetById(PriceValue.Id);

                PriceLog priceLog = new PriceLog();
                priceLog.Date = DateTime.Now;
                priceLog.Editor = Constants.CurrentUser.Title;
                priceLog.PricePeriodId = PriceValue.PricePeriod.Id;
                priceLog.PriceTypeId = PriceValue.PriceType.Id;
                priceLog.MaterialNomId = PriceValue.MaterialNom.Id;
                priceLog.PriceValueId = PriceValue.Id;
                //priceLog.OldValue = priceVal.PriceVal;
                DataHelper.Save(priceLog);
            }

            DataHelper.Save(PriceValue);

            PriceValue.Changed = false;
            base.SaveButtonClicked();
        }

        protected override IEntity GetEntity()
        {
            return PriceValue;
        }

        protected override void SetEntity(IEntity value)
        {
            if (PriceValue == null)
            {
                PriceValue = value as PriceValue;
            }

            if (PriceValue != null) PriceValue.Changed = false;
        }
        protected override void BindData()
        {
            base.BindData();

            BindEditor(sePriceValue, PriceValue, x => x.PriceVal);

            bePricePeriod.DataBindings.Clear();
            bePricePeriod.DataBindings.Add("EditValue", PriceValue, "PricePeriod.DateBegin", true,
                DataSourceUpdateMode.OnPropertyChanged);

            bePriceType.DataBindings.Clear();
            bePriceType.DataBindings.Add("EditValue", PriceValue, "PriceType.Name", true,
                DataSourceUpdateMode.OnPropertyChanged);

            try
            {
                beMaterial.DataBindings.Clear();
                beMaterial.DataBindings.Add("EditValue", PriceValue, "MaterialNom.VendorMaterialNom", true,
                    DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {

                Exception e = ex.GetBaseException();
            }
        }

        private void bePricePeriod_Click(object sender, System.EventArgs e)
        {
            FxPricePeriods pricePeriods = new FxPricePeriods();
            pricePeriods.SetSingleSelectMode(PriceValue.PricePeriod);
            DialogResult dialogResult = pricePeriods.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && pricePeriods.SelectedItem != null)
                PriceValue.PricePeriod = pricePeriods.SelectedItem as PricePeriod;
        }

        private void bePriceType_Click(object sender, System.EventArgs e)
        {
            FxPriceTypes priceTypes = new FxPriceTypes();
            priceTypes.SetSingleSelectMode(PriceValue.PricePeriod);
            DialogResult dialogResult = priceTypes.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && priceTypes.SelectedItem != null)
                PriceValue.PriceType = priceTypes.SelectedItem as PriceType;
        }

        private void beMaterial_Click(object sender, System.EventArgs e)
        {
            FxMaterialNomenclature materialNomenclature = new FxMaterialNomenclature();
            materialNomenclature.SetSingleSelectMode(PriceValue.PricePeriod);
            DialogResult dialogResult = materialNomenclature.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && materialNomenclature.SelectedItem != null)
                PriceValue.MaterialNom = materialNomenclature.SelectedItem as MaterialNom;
        }
    }
}