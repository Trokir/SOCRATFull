using System.Windows.Forms;
using Socrat.Core;
using Socrat.UI.Core;

namespace Socrat.Module.Settings
{
    public partial class FxGeneralSettings : FxBaseForm
    {
        private CxMenuTree cxMenuEditor;
        private CxModules cxModules;
        private CxUserList cxUserList;
        private CxRoles cxRoles;

        public FxGeneralSettings()
        {
            InitializeComponent();

            cxMenuEditor = new CxMenuTree();
            tpMainMenu.Controls.Add(cxMenuEditor);
            cxMenuEditor.Dock = DockStyle.Fill;

            cxModules = new CxModules();
            cxModules.DialogOutput += _DialogOutput;
            tpModules.Controls.Add(cxModules);
            cxModules.Dock = DockStyle.Fill;

            cxRoles = new CxRoles();
            cxRoles.DialogOutput += _DialogOutput;
            tpRoles.Controls.Add(cxRoles);
            cxRoles.Dock = DockStyle.Fill;

            cxUserList = new CxUserList();
            cxUserList.DialogOutput += _DialogOutput;
            tpUsers.Controls.Add(cxUserList);
            cxUserList.Dock = DockStyle.Fill;

        }

        private void _DialogOutput(object sender, WindowOutputEventArgs ta)
        {
            OnDialogOutput(ta);
        }
    }
}