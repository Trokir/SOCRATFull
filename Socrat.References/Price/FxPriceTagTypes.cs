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
    public partial class FxPriceTagTypes : FxGenericListTable<PriceTagType>
    {
        private IPriceService _priceService;
        public FxPriceTagTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Наименование", "Name", 160, 0);
            AddColumn("Обозначение", "Designation", 140, 1);
        }

        protected override string GetTitle()
        {
            return "Размерности";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceTagTypeEdit();
        }
    }
}