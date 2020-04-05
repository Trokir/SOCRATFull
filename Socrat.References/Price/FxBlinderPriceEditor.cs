using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxBlinderPriceEditor : FxBaseSimpleDialog
    {
        private CxBlinderPrice _cxBlinderPrice;
        public List<PricePeriod> PricePeriods { get; set; }

        private PriceType _priceType;

        protected override IEntity GetEntity()
        {
            return PriceType;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceType = value as PriceType;
        }
        public PriceValue PriceValue { get; set; }
        public PriceType PriceType
        {
            get { return _priceType; }
            set
            {
                _priceType = value;
                Text = _priceType.Name;

            }
        }
        public Core.Entities.Price Price { get; set; }
        public List<PriceValue> PriceValues { get; set; }


        public FxBlinderPriceEditor()
        {
            InitializeComponent();
            tePeriod.Enabled = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            InitPriceType();

        }
        private void InitPriceType()
        {

            //PricePeriods = _priceService.GetPriceInfoById(Price.Id).GetPricePeriods().ToList();
            _cxBlinderPrice = new CxBlinderPrice(Price, PricePeriods.OrderByDescending(p => p.DateBegin).DefaultIfEmpty(new PricePeriod()).First(), PriceType);

            DateTime? dt = PricePeriods.OrderByDescending(p => p.DateBegin).DefaultIfEmpty(new PricePeriod()).First()
                .DateBegin;

            if (dt.HasValue)
            {
                tePeriod.Text = dt.Value.ToString("dd MMMM yyyy");
            }
            //_cxBlinderPrice.DialogOutput += _cxBlinderPrice_DialogOutput;
            //OnDialogOutput(_cxBlinderPrice, DialogOutputType.Dialog);

            pcPrice.Controls.Add(_cxBlinderPrice);
            _cxBlinderPrice.Dock = DockStyle.Fill;
        }

        private void _cxBlinderPrice_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}
