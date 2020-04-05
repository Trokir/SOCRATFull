using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.UI.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceTagTypeEdit : FxBaseSimpleDialog
    {
        public PriceTagType PriceTagType { get; set; }
        private IPriceService _priceService;
        public FxPriceTagTypeEdit()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override IEntity GetEntity()
        {
            return PriceTagType;
        }

        protected override void SetEntity(IEntity value)
        {
            PriceTagType = value as PriceTagType;
        }
        protected override List<BaseEdit> GetControlsForValidation()
        {
            return new List<BaseEdit> { teName, teDesignation };
        }

        protected override void BindData()
        {
            base.BindData();

            BindEditor(teName, PriceTagType, x => x.Name);
            BindEditor(teDesignation, PriceTagType, x => x.Designation);
        }
    }
}