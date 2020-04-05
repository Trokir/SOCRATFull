using System;
using Socrat.DataProvider;
using Socrat.UI.Core;

namespace Socrat.Startup
{
    public partial class FxAbout : FxBaseForm
    {
        public FxAbout()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            teConnect.Text = EntityFrameworkConnection.SocratEntities.Database.Connection.ConnectionString;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
