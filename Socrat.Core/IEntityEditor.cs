using System;
using System.Windows.Forms;

namespace Socrat.Core
{
    public interface IEntityEditor: ITabable
    {
        event EventHandler SaveButtonClick;
        event EventHandler PrintButtonClick;
        FormStartPosition StartPosition { get; set; }
        IEntity Entity { get; set; }
        bool ReadOnly { get; set; }
    }
}
