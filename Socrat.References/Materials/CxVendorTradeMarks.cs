using System.Collections.ObjectModel;
using System.Linq;
using Socrat.Core;
using Socrat.Core.Entities;

namespace Socrat.References.Materials
{
    public partial class CxVendorTradeMarks : CxGenericListTable<TradeMark>
    {
        public Vendor Vendor { get; set; }
        public Material MaterialFilter { get; set; }
        public ObservableCollection<TradeMark> _Items;
        public CxVendorTradeMarks()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddObjectColumn("Материал", "Material", 160, 0);
            AddObjectColumn("Производитель", "Vendor", 160, 1);
            AddObjectColumn("Бренд", "Brand", 160, 2);
            AddColumn("Наименование", "Name", 200, 3);
        }

        protected override IEntityEditor GetEditor()
        {
            var _fx = new FxTradeMarkEdit();
            _fx.FixVendor = true;
            _fx.Vendor = Vendor;
            return _fx;
        }

        protected override ObservableCollection<TradeMark> GetItems()
        {
            //if (_Items == null)
            //{
            //    if (Vendor != null)
            //    {
            //        if (MaterialFilter == null)
            //            _Items = Vendor.TradeMarks;
            //        else
            //            _Items = new ObservableCollection<TradeMark>(Vendor.TradeMarks.Where(x =>
            //                x.Material.Id == MaterialFilter.Id));
            //    }
            //}
            //else
            //if (MaterialFilter != null)
            //    _Items = new ObservableCollection<TradeMark>(_Items.Where(x => x.Material.Id == MaterialFilter.Id));
            //return _Items;
            return Vendor.TradeMarks;
        }

        protected override TradeMark GetNewInstance()
        {
            return new TradeMark
            {
                Vendor = this.Vendor,
                Material = Vendor.VendorMaterials.Count == 1 ? Vendor.VendorMaterials.First().Material : null
            };
        }
    }
}
