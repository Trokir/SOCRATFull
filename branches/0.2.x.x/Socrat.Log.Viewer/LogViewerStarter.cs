using System.Windows.Forms;
using Socrat.Lib;
using Socrat.Lib.Module;
using Socrat.UI.Core;


namespace Socrat.Log.Viewer
{
    /// <summary>
    /// Стартовый класс модуля
    /// </summary>
    [ModuleStarter]
    public class LogViewerStarter : IModule
    {
        public string Name
        {
            get { return GetModuleName(); }
        }
        public SqlHelper SqlHelper { get; set; }
        public ITabable Form
        {
            get { return GetModuleForm(); }
        }

        private FxBaseForm GetModuleForm()
        {
            return new FxLogView();
        }


        private string GetModuleName()
        {
            return "Просмотр лога";
        }
    }
}
