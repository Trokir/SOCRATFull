using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.References.Materials;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceTypeEdit : FxBaseSimpleDialog
    {
        public PriceType PriceType { get; set; }
        private IPriceService _priceService;
        public FxPriceTypeEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return PriceType;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceType = value as PriceType;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, bePriceTag };
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, PriceType, x => x.Name);

            beMaterial.DataBindings.Clear();
            beMaterial.DataBindings.Add("EditValue", PriceType, "Material", true,
                DataSourceUpdateMode.OnPropertyChanged);

            bePriceTag.DataBindings.Clear();
            bePriceTag.DataBindings.Add("EditValue", PriceType, "PriceTagType", true,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        private void beMaterial_Click(object sender, EventArgs e)
        {
            FxMaterials prices = new FxMaterials();
            prices.SetSingleSelectMode(PriceType.Material);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceType.Material = prices.SelectedItem as Core.Entities.Material;
        }

        private void bePriceTag_Click(object sender, EventArgs e)
        {
            FxPriceTagTypes prices = new FxPriceTagTypes();
            prices.SetSingleSelectMode(PriceType.PriceTagType);
            DialogResult dialogResult = prices.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && prices.SelectedItem != null)
                PriceType.PriceTagType = prices.SelectedItem as Core.Entities.PriceTagType;
        }
    }
}