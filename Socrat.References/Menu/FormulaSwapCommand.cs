using System;
using Socrat.Core;

namespace Socrat.References.Menu
{
    /// <summary>
    /// Команда изменения формулы изделия
    /// </summary>
    public class FormulaSwapCommand : MaterialAddCommand
    {
        public FormulaSwapCommand(Action<MaterialEnum> executeMethod, MaterialEnum materialEnum):base(executeMethod, materialEnum)
        {
        }
    }
}