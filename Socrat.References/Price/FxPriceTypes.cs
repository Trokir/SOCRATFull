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
    public partial class FxPriceTypes : FxGenericListTable<PriceType>
    {
        private IPriceService _priceService;
        public FxPriceTypes()
        {
            InitializeComponent();
            _priceService = CompositionRoot.Resolve<IPriceService>();
        }

        protected override void InitColumns()
        {
            AddColumn("Название", "Name", 160, 0);
            AddColumn("Материал", "Material.Name", 140, 1);
            AddColumn("Размерность", "PriceTagType.Designation", 140, 3);
        }

        protected override string GetTitle()
        {
            return "Разделы прайсов";
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxPriceTypeEdit();
        }

    }
}