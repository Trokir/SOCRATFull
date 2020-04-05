using Socrat.UI.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Socrat.Common.UI;

namespace Socrat.Module.Order.Processings
{
    public partial class FxMailList : FxBaseForm
    {
        CxMailCorrespondence cxOrders;
        public FxMailList()
        {
            InitializeComponent();

            cxOrders = new CxMailCorrespondence();
            panelControl1.Controls.Add(cxOrders);
            cxOrders.Dock = DockStyle.Fill;
            cxOrders.DialogOutput += CxOrders_DialogOutput;

        }

        private void CxOrders_DialogOutput(object sender, WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}
