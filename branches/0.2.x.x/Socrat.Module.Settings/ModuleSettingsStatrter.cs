using System.Windows.Forms;
using DevExpress.Data.Filtering.Helpers;
using Socrat.Lib;
using Socrat.Lib.Module;

namespace Socrat.Module.Settings
{
    [ModuleStarter]
    public class ModuleSettingsStatrter: IModule
    {
        public string Name
        {
            get { return GetName(); }
        }

        public SqlHelper SqlHelper { get; set; }
        public ITabable Form
        {
            get { return GetForm(); }
        }

        private ITabable GetForm()
        {
           return new FxGeneralSettings();
        }

        private string GetName()
        {
            return "Модуль основных настроек";
        }
    }
}
