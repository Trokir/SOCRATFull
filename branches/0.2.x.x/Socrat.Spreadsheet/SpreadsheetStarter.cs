using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Socrat.Lib;
using Socrat.Lib.Module;

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
