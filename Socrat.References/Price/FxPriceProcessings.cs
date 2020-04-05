using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.References.Materials;

namespace Socrat.References.Price
{
    public partial class FxPriceProcessings : FxGenericListTable<PriceProcessing>
    {
        private IPriceService _priceService;
        public FxPriceProcessings()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Обработка", "Processing.Name", 160, 0);
            AddColumn("Период прайса", "PricePeriod.DateBegin", 140, 1);
            AddColumn("Скидка", "Discount", 140, 2);
            AddColumn("Delta", "Delta", 140, 3);
        }

        protected override string GetTitle()
        {
            return "Цены за операции";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxVendorMaterialNomEdit(); //new FxPriceProcessingEdit();
        }
    }
}