using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceElementEdit : FxBaseSimpleDialog
    {
        private PriceValue _priceValue;
        public PriceValue PriceValue
        {
            get
            {
                return _priceValue;
            }
            set
            {
                _priceValue = value;
            }
        }

        protected override IEntity GetEntity()
        {
            return PriceValue;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceValue = value as PriceValue;
        }

        protected override void BindData()
        {
            base.BindData();
            BindEditor(teName, PriceValue, "MaterialNom.MaterialSizeType.MaterialMarkType.Name");
            BindEditor(tePrice, PriceValue, x => x.PriceVal);
        }

        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, tePrice };
        }

        public FxPriceElementEdit()
        {
            InitializeComponent();
            SaveButtonClick += FxPriceElementEdit_SaveButtonClick;
            //tePrice.TextChanged += TePrice_TextChanged;
        }

        protected override void OnSaveButtonClick()
        {
            base.OnSaveButtonClick();
        }

        private void TePrice_TextChanged(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
        }

        private void FxPriceElementEdit_SaveButtonClick(object sender, EventArgs e)
        {
            IRepository<PriceValue> repository = DataHelper.GetRepository<PriceValue>();
            repository.Save(PriceValue);
        }
    }
}
