using System.Linq;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;
using Socrat.Core;

namespace Socrat.References.Price
{
    public partial class FxPriceSlozes : FxGenericListTable<PriceSloz>
    {
        private IPriceService _priceService;
        private Core.Entities.Price _price;
        public FxPriceSlozes()
        {
            Init();
        }

        public FxPriceSlozes(Core.Entities.Price price)
        {
            _price = price;
            Init();
        }
        private void Init()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
            CxTableList.SetActionsButtonVisibility(false);
            CxTableList.ShowFilterPanel(false);
            CxTableList.ShowGroupPanel(false);
        }

        protected override void LoadData()
        {
            if (_price != null)
            {
                Items = Repository.GetAll(p => p.PriceId == _price.Id).ToList();
            }
            else
            {
                base.LoadData();
            }
        }

        protected override void InitColumns()
        {
            AddColumn("Тип сложности", "SlozType.Name", 340, 0);
            AddColumn("Значение", "PriceSlozName", 50, 1);
            AddColumn("Скидка", "Discount", 50, 2);
            AddColumn("Дельта", "Delta", 50, 3);
        }

        protected override string GetTitle()
        {
            return "Наценки за сложность";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceSlozEdit(_price);
        }
    }
}