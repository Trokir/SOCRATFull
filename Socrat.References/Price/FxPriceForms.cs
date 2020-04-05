using System.Linq;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxPriceForms : FxGenericListTable<PriceForm>
    {
        private IPriceService _priceService;
        private Core.Entities.Price _price;
        public FxPriceForms()
        {
            Init();
        }

        public FxPriceForms(Core.Entities.Price price)
        {
            _price = price;
            Init();
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

        private void Init()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
            CxTableList.SetActionsButtonVisibility(false);
            CxTableList.ShowFilterPanel(false);
            CxTableList.ShowGroupPanel(false);
        }

        protected override void InitColumns()
        {
            AddColumn("Тип формы", "FormType.Name", 150, 0);
            AddColumn("Значение", "PriceVal", 150, 1);
        }

        protected override string GetTitle()
        {
            return "Наценки за фигуры (по типам фигур)";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceFormEdit(_price);
        }
    }
}