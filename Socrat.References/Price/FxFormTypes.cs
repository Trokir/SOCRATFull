using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxFormTypes : FxGenericListTable<FormType>
    {
        private IPriceService _priceService;
        public FxFormTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 160, 0);
        }

        protected override string GetTitle()
        {
            return "Типы фигур";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxFormTypeEdit();
        }
    }
}