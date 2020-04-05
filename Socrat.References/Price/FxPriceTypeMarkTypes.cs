using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Socrat.Core;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.DI;
using Socrat.Core.Entities;

namespace Socrat.References.Price
{
    public partial class FxPriceTypeMarkTypes : FxGenericListTable<PriceTypeMarkType>
    {
        private IPriceService _priceService;
        public FxPriceTypeMarkTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }
        protected override void InitColumns()
        {
            AddColumn("Раздел прайса", "PriceType.Name", 160, 0);
            AddColumn("Тип материала", "MaterialMarkType.Name", 140, 1);
        }

        protected override string GetTitle()
        {
            return "Список типоразмеров раздела прайса";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceTypeMarkTypeEdit();
        }
    }
}