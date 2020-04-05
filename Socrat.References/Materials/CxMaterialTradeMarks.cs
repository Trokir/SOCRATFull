using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;
using Socrat.DataProvider;

namespace Socrat.References.Materials
{
    public partial class CxMaterialTradeMarks : CxGenericListTable<TradeMark>
    {
        private Material _material;
        public Material Material
        {
            get => _material;
            set => SetMaterial(value);
        }

        private void SetMaterial(Material value)
        {
            _material = value;
            SourceItems = Material?.TradeMarks;
            RefreshData();
        }

        public CxMaterialTradeMarks()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 200, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            
            return new FxNamedEntityEdit("Наименование торгодой марки");
        }

        private ObservableCollection<TradeMark> _Items;
        protected override ObservableCollection<TradeMark> GetItems()
        {
            if (_Items == null && Material != null)
                _Items = new ObservableCollection<TradeMark>(
                    DataHelper.GetAll<TradeMark>().Where(x => x.MaterialId == Material.Id && x.BrandId == null && x.VendorId == null));
            return _Items;
        }

        protected override TradeMark GetNewInstance()
        {
            return new TradeMark
            {
                Material = this.Material
            };
        }
    }
}
