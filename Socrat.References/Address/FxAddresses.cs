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

namespace Socrat.References.Address
{
    public partial class FxAddresses : FxGenericListTable<Core.Entities.Address>
    {
        public Func<List<Core.Entities.Address>> GetAddressesMethod { get; set; }

        public FxAddresses()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Адрес", "Title", 300, 0);
        }

        protected override IEntityEditor GetEditor()
        {
            return new FxAddressEdit();
        }

        protected override List<Core.Entities.Address> GetItems()
        {
            if (GetAddressesMethod != null)
            {
                _items = GetAddressesMethod.Invoke();
                return _items;
            }
            return base.GetItems();
        }

        protected override string GetTitle()
        {
            return "Введеные адреса";
        }
    }
}