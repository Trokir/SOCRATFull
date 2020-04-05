using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxPriceValues : FxGenericListTable<PriceValue>
    {
        private IPriceService _priceService;
        public FxPriceValues()
        {
            InitializeComponent();
           // _priceService = CompositionRoot.Resolve<IPriceService>();
        }
        protected override void InitColumns()
        {
            AddColumn("Раздел прайса", "PriceType.Name", 160, 0);
            AddColumn("Период прайса", "PricePeriod.DateBegin", 140, 1);
            AddColumn("Цена", "PriceVal", 140, 2);
            AddColumn("Delta", "Delta", 140, 3);

            AddColumn("Код", "MaterialNom.Code", 180, 4);
            AddObjectColumn("Материал", "MaterialNom.VendorMaterialNom", 120, 5);
            AddColumn("Толщина", "MaterialNom.Thickness", 120, 6);
            AddColumn("Код 1С", "MaterialNom.Code1C", 180, 7);
        }

        protected override string GetTitle()
        {
            return "Цены на номенклатуру раздела прайса";
        }

        protected override IEntityEditor GetEditor()
        {
            
            return new FxPriceValueEdit();
        }
    }
}