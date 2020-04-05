using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxPricePeriods : FxGenericListTable<PricePeriod>
    {
        private IPriceService _priceService;
        public FxPricePeriods()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Прайс", "Price.Name", 160, 0);
            AddColumn("Дата начала действия прайса", "DateBegin", 140, 1);
            AddColumn("Базовая цена СПО", "BaseSpo", 140, 3);
            AddColumn("Базовая цена СПД", "BaseSpd", 140, 4);
        }

        protected override string GetTitle()
        {
            return "Список периодов прайсов";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPricePeriodEdit();
        }
    }
}