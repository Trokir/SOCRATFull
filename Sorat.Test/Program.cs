using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Socrat.Module.Order;
using Socrat.Test;

namespace Sorat.Test
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Socrat.Shape.FxShapeEditor _fxTestShapeForm = new Socrat.Shape.FxShapeEditor();
            FxFormulaEdit _fx = new FxFormulaEdit();
            //_fx.Formula = FormulaParser.Parse("(6Т1[Пр/Зак]-0,38PVB-0,38PVBСиняя-8М1[Шл/Зак]-0,76PVB-4М1[Пр/ЗО/Т])[Зл]-16Поли#Ar-8М1[Пол/Т]-12Липо[Шуко]#Ar-12М1[Шл]");
          //  _fx.Formula = FormulaParser.Parse("4-10-4");
            Application.Run(_fxTestShapeForm);
            
            //Application.Run(new PackageVisualEditor());
        }
    }
}
