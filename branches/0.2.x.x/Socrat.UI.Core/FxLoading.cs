using System.Windows.Forms;
using DevExpress.XtraWaitForm;
namespace Socrat.UI.Core
{
    public partial class FxLoading : WaitForm
    {
        public FxLoading()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}
