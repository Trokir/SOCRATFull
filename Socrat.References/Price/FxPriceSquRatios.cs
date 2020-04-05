using System.Linq;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;

namespace Socrat.References.Price
{
    public partial class FxPriceSquRatios : FxGenericListTable<Core.Entities.PriceSquRatio>
    {
        private IPriceService _priceService;
        private Core.Entities.Price _price;
        public FxPriceSquRatios()
        {
            Init();
        }

        public FxPriceSquRatios(Core.Entities.Price price)
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
            AddColumn("Площадь, до (кв.м.)", "Squ", 160, 0);
            AddColumn("Коэффициент цены", "Ratio", 140, 1);
        }

        protected override string GetTitle()
        {
            return "Наценки за площадь изделия";
        }

        protected override IEntityEditor GetEditor()
        {
            return _price == null ? null : new FxPriceSquRatioEdit(_price);
        }
    }
}