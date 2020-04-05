using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxGeneralSettings : FxBaseForm
    {
        public FxGeneralSettings()
        {
            InitializeComponent();

            cxModules1.DialogOutput += CxModules1_DialogOutput;
            cxRoles.DialogOutput += CxModules1_DialogOutput;
            cxUserList1.DialogOutput += CxModules1_DialogOutput;
        }

        private void CxModules1_DialogOutput(object sender, Lib.WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta.NewTab, ta.OutputType);
        }
    }
}