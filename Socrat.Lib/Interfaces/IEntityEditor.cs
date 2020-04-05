using System;
using System.Windows.Forms;

namespace Socrat.Lib
{
    public interface IEntityEditor: ITabable
    {
        event EventHandler SaveButtonClick;
        event EventHandler PrintButtonClick;
        IEntity Entity { get; set; }
        //void Show(IWin32Window owner);
        //DialogResult ShowDialog(IWin32Window owner);
        FormStartPosition StartPosition { get; set; }
        //void Close();
        bool ReadOnly { get; set; }
    }
}
