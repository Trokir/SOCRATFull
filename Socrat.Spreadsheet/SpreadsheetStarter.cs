using Socrat.Lib;
using Socrat.Lib.Module;
using ITabable = Socrat.Core.ITabable;

namespace Socrat.Spreadsheet
{
    [ModuleStarter]
    public class SpreadsheetStarter : IModule
    {
        public string Name
        {
            get
            {
                return "Таблица";
            }
        }
        public SqlHelper SqlHelper { get; set; }

        public ITabable Form
        {
            get { return new FxSpreadSheet(); }

        }
    }
}
