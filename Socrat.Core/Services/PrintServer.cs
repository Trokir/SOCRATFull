using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Socrat.Core.Services
{
    public class PrintServer
    {
        public static void Print(IEntity entity, object template = null)
        {
            if (template != null)
            {
                PrintInternal(template);
                return;
            }
            if (entity is ITemplated templatedEntity)
            {
                PrintInternal(templatedEntity);
                return;
            }

            XtraMessageBox.Show(
                "Объект данных не имеет сопоставленного шаблона для печати. Нечего печатать!",
                "Внимание!",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Stop);
        }

        private static void PrintInternal(object template)
        {

        }
    }
}
