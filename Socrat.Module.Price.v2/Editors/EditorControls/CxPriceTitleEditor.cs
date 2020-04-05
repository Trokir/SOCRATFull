using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Socrat.Module.Price
{
    public partial class CxPriceTitleEditor : XtraUserControl
    {
        public Core.Entities.Price Price { get; set; }

        public CxPriceTitleEditor()
        {
            InitializeComponent();
        }

        public void BindData(Core.Entities.Price price)
        {
            Price = price;
            lcName.DataBindings.Add("Text", Price, "Title", true, DataSourceUpdateMode.OnPropertyChanged);

            if (Price.Division != null)
                lcDivision.DataBindings.Add("Text", Price, "Division.Title", true, DataSourceUpdateMode.OnPropertyChanged);

            if (Price.Customer != null)
                lcCustomer.DataBindings.Add("Text", Price, "Customer.FullName", true, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
