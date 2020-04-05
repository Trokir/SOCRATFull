using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using System.ComponentModel;

namespace Socrat.References.Price
{
    public partial class FxPrices : FxGenericListTable<Core.Entities.Price>
    {
        private IPriceService _priceService;
        public FxPrices()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Пр.площадка", "Division.FullName", 150, 0);
            AddColumn("Тип", "PriceType", 250, 1);
            AddColumn("Контрагент/Наименование", "PriceName", 150, 2);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceEdit();
        }
    }
}