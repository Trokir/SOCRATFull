using System;
using System.Windows.Forms;

namespace Socrat.Core
{
    /// <summary>
    /// Интерфейс окна, способного быть вкладкой и выводить вкладки
    /// </summary>
    public interface ITabable
    {
        event EventHandler<WindowOutputEventArgs> DialogOutput;
        void OnDialogOutput(ITabable outForm, DialogOutputType outputType);
        void OnDialogOutput(WindowOutputEventArgs ta);
        IntPtr Handle { get; }
        string Title { get; }
        bool ReadOnly { get; set; }
        Guid ModuleId { get; set; }
    }

    public class WindowOutputEventArgs : System.EventArgs
    {
        public ITabable NewTab { get; set; }
        public DialogOutputType OutputType { get; set; }
        public IWin32Window Owner { get; set; }

        public WindowOutputEventArgs()
        {
        }

        public WindowOutputEventArgs(ITabable newTab, DialogOutputType outputType, IWin32Window owner)
        {
            NewTab = newTab;
            OutputType = outputType;
            Owner = owner;
        }
    }

    public enum DialogOutputType
    {
        Dialog,
        Tab,
        Modal
    }
}