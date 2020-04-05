using System;
using System.Reflection;
using System.Windows.Forms;

namespace Socrat.Lib
{
    /// <summary>
    /// Интерфей окна, способного быть вкладкой и выводить вкладки
    /// </summary>
    public interface ITabable
    {
        event WindowOutputHandler DialogOutput;
        void OnDialogOutput(ITabable outForm, DialogOutputType outputType);
        IntPtr Handle { get; }
        string Title { get; }
        bool ReadOnly { get; set; }
    }
}
