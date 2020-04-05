
using Socrat.Core.Entities;

namespace Socrat.References.Formula
{
    public partial class CxItemProperties : DevExpress.XtraEditors.XtraUserControl
    {
        public OrderRow OrderRow { get; set; }

        public CxItemProperties()
        {
            InitializeComponent();
            Load += CxItemProperties_Load;
        }

        private void CxItemProperties_Load(object sender, System.EventArgs e)
        {
            pgcItemParams.SelectedObject = OrderRow;
            if (OrderRow.Formula != null)
                tsShowSurfaceNumbers.IsOn = OrderRow.Formula.ShowPositionsNumbers;
        }

        private void tsShowSurfaceNumbers_EditValueChanged(object sender, System.EventArgs e)
        {
            if (OrderRow.Formula != null)
                OrderRow.Formula.ShowPositionsNumbers = tsShowSurfaceNumbers.IsOn;
        }
    }
}
