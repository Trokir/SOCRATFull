using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socrat.Lib.Module
{
    /// <summary>
    /// Аттрибут для маркировки стартового класса модуля
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ModuleStarterAttribute: Attribute
    {
    }
}
