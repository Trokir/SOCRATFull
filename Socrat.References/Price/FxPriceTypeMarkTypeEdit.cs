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
    public partial class FxPriceTypeMarkTypeEdit : FxBaseSimpleDialog
    {
        public PriceTypeMarkType PriceTypeMarkType { get; set; }
        private IPriceService _priceService;
        public FxPriceTypeMarkTypeEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return PriceTypeMarkType;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceTypeMarkType = value as PriceTypeMarkType;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { beMaterialMarkType, bePriceType };
        }

        private void bePriceType_Click(object sender, EventArgs e)
        {
            FxPriceTypes priceTypes = new FxPriceTypes();
            priceTypes.SetSingleSelectMode(PriceTypeMarkType.PriceType);
            DialogResult dialogResult = priceTypes.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && priceTypes.SelectedItem != null)
                PriceTypeMarkType.PriceType = priceTypes.SelectedItem as Core.Entities.PriceType;
        }

        private void beMaterialMarkType_Click(object sender, EventArgs e)
        {
            FxMaterialMarkTypes materialTypes = new FxMaterialMarkTypes();
            materialTypes.SetSingleSelectMode(PriceTypeMarkType.MaterialMarkType);
            DialogResult dialogResult = materialTypes.ShowDialog(this);
            if (dialogResult != DialogResult.Cancel && materialTypes.SelectedItem != null)
                PriceTypeMarkType.MaterialMarkType = materialTypes.SelectedItem as Core.Entities.MaterialMarkType;
        }

        protected override string GetTitle()
        {
            return "Типоразмер раздела прайса";
        }

        protected override void BindData()
        {
            base.BindData();

            bePriceType.DataBindings.Clear();
            bePriceType.DataBindings.Add("EditValue", PriceTypeMarkType, "PriceType", true,
                DataSourceUpdateMode.OnPropertyChanged);

            beMaterialMarkType.DataBindings.Clear();
            beMaterialMarkType.DataBindings.Add("EditValue", PriceTypeMarkType, "MaterialMarkType", true,
                DataSourceUpdateMode.OnPropertyChanged);

        }
    }
}