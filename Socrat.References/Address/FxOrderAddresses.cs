using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Customization;
using Socrat.UI.Core;

namespace Socrat.References.Address
{
    public partial class FxOrderAddresses : FxBaseForm
    {
        public Core.Entities.Order Order { get; set; }
        public CxOrderAddresses CxOrderAddresses;
        public event EventHandler<Core.Entities.Address> AddressSelected;

        public FxOrderAddresses()
        {
            InitializeComponent();
            Load += FxOrderAddresses_Load;
        }

        private void FxOrderAddresses_Load(object sender, System.EventArgs e)
        {
            Init();
        }

        private void Init()
        {
            CxOrderAddresses = new CxOrderAddresses();
            CxOrderAddresses.SetSingleSelectMode(null);
            CxOrderAddresses.Order = Order;
            CxOrderAddresses.DialogOutput += CxOrderAddresses_DialogOutput;
            CxOrderAddresses.ItemSelected += CxOrderAddresses_ItemSelected;
            panelControl.Controls.Add(CxOrderAddresses);
            CxOrderAddresses.Dock = DockStyle.Fill;
        }

        private void CxOrderAddresses_ItemSelected(object sender, System.EventArgs e)
        {
            AddressSelected?.Invoke(this, (Core.Entities.Address)CxOrderAddresses.SelectedItem);
            Close();
        }

        private void CxOrderAddresses_DialogOutput(object sender, Core.WindowOutputEventArgs e)
        {
            OnDialogOutput(e);
        }
    }
}