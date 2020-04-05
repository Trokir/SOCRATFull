using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxPriceSelectTypes : FxGenericListTable<PriceSelectType>
    {
        private IPriceService _priceService;
        public FxPriceSelectTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Прайс", "Price.Name", 160, 0);
            AddColumn("Раздел прайса", "PriceType.Name", 140, 1);
        }

        protected override string GetTitle()
        {
            return "Список разделов у прайса";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceSelectTypeEdit();
        }
    }
}