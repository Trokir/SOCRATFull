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
using Socrat.Core.Entities.Tender;

namespace Socrat.References.Tender
{
    public partial class FxTenders : FxGenericListTable<Core.Entities.Tender.Tender>
    {
        public Core.Entities.Customer Customer { get; set; }

        public FxTenders()
        {
            InitializeComponent();
        }

        protected override void InitColumns()
        {
            AddColumn("Имя", "Name",  200, 0);
            AddColumn("Создан", "DateCreate", 60, 1);
            AddColumn("Закрыт", "IsClose",  40, 2);
        }

        protected override IEntityEditor GetEditor(OpenMode openMode = OpenMode.Default)
        {
            return new FxTenderEdit { OpenMode = openMode};
        }

        protected override Core.Entities.Tender.Tender GetNewInstance()
        {
            Core.Entities.Tender.Tender _tender = 
                new Core.Entities.Tender.Tender { DateCreate = DateTime.Now, Loaded = true };
            if (Customer != null)
                _tender.TenderCustomers.Add(new TenderCustomer { Tender = _tender, Customer = this.Customer, Loaded = true});
            return _tender;
        }
    }
}