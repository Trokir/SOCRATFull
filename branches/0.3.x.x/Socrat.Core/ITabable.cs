using System;

namespace Socrat.Core
{
    /// <summary>
    /// Интерфейс окна, способного быть вкладкой и выводить вкладки
    /// </summary>
    public interface ITabable
    {
        event EventHandler<WindowOutputEventArgs> DialogOutput;
        void OnDialogOutput(ITabable outForm, DialogOutputType outputType);
        IntPtr Handle { get; }
        string Title { get; }
        bool ReadOnly { get; set; }
    }

    public class WindowOutputEventArgs : System.EventArgs
    {
        public ITabable NewTab { get; set; }
        public DialogOutputType OutputType { get; set; }
    }

    public enum DialogOutputType
    {
        Dialog,
        Tab
    }
}